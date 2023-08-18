using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IServices;
using Clean.WinF.Domain.Repository;
using Clean.WinF.Infrastructure.Utilities;
using Clean.WinF.Shared.Constants;
using Clean.WinF.Shared.DTOs.Users;
using Clean.WinF.Shared.Enums;
using Clean.WinF.Shared.ErrorMessage;
using Clean.WinF.Shared.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Services
{
    public class RoleService : IRoleService
    {
        private readonly IConfiguration _config;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly IAsyncRepository<Permission> _permissionRepository;
        private readonly ILogger<RoleService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IAsyncRepository<Role> roleRepository,
                           ILogger<RoleService> logger,
                           IConfiguration config, IUnitOfWork unitOfWork, IAsyncRepository<Permission> permissionRepository)

        {
            _config = config;
            _roleRepository = roleRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _permissionRepository = permissionRepository;
        }

        public async Task<RoleDto> CreateNewRole(RoleDto addRole)
        {
            var result = new RoleDto();

            if (string.IsNullOrEmpty(addRole.RoleName))
            {
                result.CustomError = CustomErrorCode.BP_ROLE_NAME_EMPTY;
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_NAME_EMPTY, addRole.RoleName);
                return result;
            }

            //check existed db
            var existedRole = await CheckExistedRoleInDB(addRole, nameof(RoleStatus.Active), nameof(RoleRequest.Create));
            if (existedRole)
            {
                result.CustomError = CustomErrorCode.BP_ROLE_EXISTED_ALREADY;
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_EXISTED_ALREADY, addRole.RoleName);
                return result;
            }

            //Implement checking special characters for role name and description
            if (!string.IsNullOrEmpty(addRole.RoleName) && BluePrintUtility.CheckSpecialCharacter(addRole.RoleName.Trim()))
            {
                result.Message = CustomErrorCode.BP_ROLE_EXIST_SPECIAL_CHARS_NAME;
                result.CustomError = string.Format(CustomErrorMessage.BP_ROLE_EXIST_SPECIAL_CHARS_NAME, addRole.RoleName);
                return result; 
            }

            if (!string.IsNullOrEmpty(addRole.Description) && BluePrintUtility.CheckSpecialCharacter(addRole.Description.Trim()))
            {
                result.Message = CustomErrorCode.BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION;
                result.CustomError = string.Format(CustomErrorMessage.BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION);
                return result;
            }

            //validate selected permissions
            if (addRole.Permissions != null && addRole.Permissions.Count > 0)
            {
                foreach (var permission in addRole.Permissions)
                {
                    if (int.TryParse(permission, out int permissionID))
                    {
                        var isValid = await CheckExistedPermisionInDB(permissionID);
                        if (!isValid)
                        {
                            result.CustomError = CustomErrorCode.BP_PERMISSION_NOT_FOUND;
                            result.Message = string.Format(CustomErrorMessage.BP_PERMISSION_NOT_FOUND, permissionID.ToString());
                            return result;
                        }
                    }
                }
            }
            else
            {
                addRole.Permissions = new List<string>();
                foreach (var item in _permissionRepository.GetAll().Select(x => x.Id))
                {
                    addRole.Permissions.Add(item.ToString());
                }
            }

            //fix case: Create new role name with the existing name           
            var existedRoleName = await CheckExistedRoleInDB(addRole, nameof(RoleStatus.Removed), nameof(RoleRequest.Create));
            if (existedRoleName)
            {
                var removedRole = _unitOfWork.RoleRepository.Query()
                .FirstOrDefaultAsync(x => x.Name.Equals(addRole.RoleName) && x.Status.Equals(nameof(RoleStatus.Removed))).Result;
                removedRole.Description = addRole.Description;
                removedRole.Status = nameof(RoleStatus.Active);
                removedRole.UpdatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : CommonConstant.ADMIN;
                removedRole.UpdatedDate = DateTime.UtcNow;
                var resultUpdated = _unitOfWork.RoleRepository.UpdateAsync(removedRole).Result;
                result = UpdateRoleDtoInfo(resultUpdated);
                return result;
            }

            //add new role to db
            var newRole = new Role()
            {
                Name = addRole.RoleName.Trim(),
                NormalizedName = addRole.RoleName.ToUpper(),
                Description = !string.IsNullOrEmpty(addRole.Description) ? addRole.Description.Trim() : string.Empty,
                Status = nameof(RoleStatus.Active),
                CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config),
                CreatedDate = DateTime.UtcNow
            };

            try
            {
                var roleDtoResult = await _unitOfWork.RoleRepository.AddAsync(newRole);
                _unitOfWork.Complete();
                addRole.RoleId = roleDtoResult.Id;

                //continue to update selected the permissions
                roleDtoResult = GetExistedRoleInDB(newRole.Name).Result;

                if (addRole.Permissions != null && addRole.Permissions.Count > 0)
                {
                    result = AddRolePermissions(addRole.Permissions, roleDtoResult, RoleRequest.Create);
                    if (result != null && !string.IsNullOrEmpty(result.CustomError))
                        return result;
                }
                //addRole.Permissions = GetExistedPermissions(roleDtoResult.RolePermissionGroups, addRole.RoleID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Message = string.Format(CustomErrorCode.BP_ROLE_CREATE_FAIL, addRole.RoleName);
                result.CustomError = CustomErrorCode.BP_ROLE_CREATE_FAIL;
                return result;
            }

            return addRole;
        }

        public async Task<Shared.DTOs.Roles.RoleGetByIdResponseItem> GetRoleById(int roleId)
        {
            var result = new Shared.DTOs.Roles.RoleGetByIdResponseItem();

            //check existed db
            var existedRole = await _unitOfWork.RoleRepository.Query().Include(b => b.RolePermissions).Include(x => x.RoleGroups).FirstOrDefaultAsync(p => p.Id == roleId);
            if (existedRole is null || existedRole.Status.Equals(nameof(RoleStatus.Removed)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_NOT_FOUND, roleId);
                result.CustomError = CustomErrorCode.BP_ROLE_NOT_FOUND;
                return result;
            }

            result.RoleId = existedRole.Id;
            result.RoleName = existedRole.Name;
            result.Description = existedRole.Description;
            result.Status = existedRole.Status;
            var permissionGroupResponse = new List<Shared.DTOs.Permission.PermissionGroupResponse>();

            foreach (var item in existedRole.RolePermissions)
            {
                var pm = _permissionRepository.Query().FirstOrDefault(x => x.Id == item.PermissionId);
                if (pm != null)
                {
                    if (pm.ParentId == 0)
                    {
                        var permissionGroupResponseItem = new Shared.DTOs.Permission.PermissionGroupResponse
                        {
                            Id = pm.Id,
                            Code = pm.Code,
                            Name = pm.Name,
                            Description = pm.Description,
                            Permissions = new List<Shared.DTOs.Permission.PermissionResponse>()
                        };
                        permissionGroupResponse.Add(permissionGroupResponseItem);
                    }
                    else
                    {
                        var permissionInList = permissionGroupResponse.FirstOrDefault(x => x.Id == pm.ParentId);
                        if (permissionInList == null)
                        {
                            var pmParent = _permissionRepository.Query().FirstOrDefault(x => x.Id == pm.ParentId);
                            var permissionGroupResponseItem = new Shared.DTOs.Permission.PermissionGroupResponse
                            {
                                Id = pmParent.Id,
                                Code = pmParent.Code,
                                Name = pmParent.Name,
                                Description = pmParent.Description,
                                Permissions = new List<Shared.DTOs.Permission.PermissionResponse>()
                            };

                            if (permissionGroupResponse.FirstOrDefault(x => x.Id == permissionGroupResponseItem.Id) == null)
                            {
                                permissionGroupResponse.Add(permissionGroupResponseItem);
                                permissionInList = permissionGroupResponseItem;
                            }
                        }
                        var permission = new Shared.DTOs.Permission.PermissionResponse
                        {
                            Id = pm.Id,
                            Name = pm.Name,
                            Code = pm.Code,
                            ParentId = pm.ParentId,
                            BelongsToRole = item.BelongToRole
                        };
                        permissionInList.Permissions.Add(permission);
                    }
                }
            }

            result.PermissionCategories = permissionGroupResponse;

            return result;
        }

        public async Task<IEnumerable<RoleDto>> ListAllRolesAsync()
        {
            var roleList = new List<RoleDto>();

            var roles = _unitOfWork.RoleRepository.Query().Include(g => g.RolePermissions).Include(r => r.RoleGroups).AsQueryable();

            if (roles is null) return null;

            foreach (var role in roles)
            {
                if (!string.IsNullOrEmpty(role.Status) && role.Status.Equals(nameof(GroupStatus.Active)))
                {
                    roleList.Add(new RoleDto
                    {
                        RoleId = role.Id,
                        RoleName = role.Name,
                        Description = role.Description,
                        UpdatedDate = role.UpdatedDate,
                        CreatedDate = role.CreatedDate,
                        Status = role.Status,
                        Permissions = GetExistedPermissions(role.RolePermissions, role.Id),
                        Groups = GetExistedGroups(role.RoleGroups, role.Id)
                    });
                }
            }

            return roleList;
        }

        public async Task<PagedList<Role>> GetRoleByConditionAsync(PagingFilteringModel commandQuery)
        {
            _logger.LogInformation($"Begining query all roles records =  {commandQuery}");

            var mainQuery = _unitOfWork.RoleRepository.Query().Include(b => b.RoleGroups).Include(b => b.RolePermissions).AsQueryable();

            try
            {
                if (!string.IsNullOrEmpty(commandQuery.QueryParams))
                {
                    var queryFilter = commandQuery.QueryParams.Trim().ToUpper();
                    mainQuery = mainQuery.Where(
                        x => (x.Name.Trim().ToUpper().Contains(queryFilter)
                        || x.Description.Trim().ToUpper().Contains(queryFilter))
                        && x.Status.Equals(nameof(GroupStatus.Active)));
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Get all roles: An error occured: {ex.ToString()}");
            }
            return await PagedList<Role>.CreateAsync(mainQuery, commandQuery.PageNumber, commandQuery.PageSize);
        }

        public async Task<RoleDto> UpdateRole(RoleDto updatedRole)
        {
            var result = new RoleDto();

            var existedRole = _unitOfWork.RoleRepository.Query()
                .Include(p => p.RoleGroups).Include(p => p.RolePermissions)
                .FirstOrDefaultAsync(x => x.Id == updatedRole.RoleId).Result;

            if (existedRole is null || existedRole.Status.Equals(nameof(RoleStatus.Removed))
                || existedRole.Status.Equals(nameof(RoleStatus.InActive)))
            {
                result.CustomError = CustomErrorCode.BP_ROLE_NOT_FOUND;
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, updatedRole.RoleId);
                return result;
            }

            //fix case: Create new role name with the existing name
            var existedRoleName = await CheckExistedRoleInDB(updatedRole, nameof(RoleStatus.Active), nameof(RoleRequest.Update));
            if (existedRoleName)
            {
                result.CustomError = CustomErrorCode.BP_ROLE_EXISTED_ALREADY;
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_EXISTED_ALREADY, updatedRole.RoleName);
                return result;
            }

            if (string.IsNullOrEmpty(updatedRole.RoleName))
            {
                result.CustomError = CustomErrorCode.BP_ROLE_NAME_EMPTY;
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_NAME_EMPTY);
                return result;
            }

            //Implement checking special characters for role name and description
            if (!string.IsNullOrEmpty(updatedRole.RoleName) && BluePrintUtility.CheckSpecialCharacter(updatedRole.RoleName.Trim()))
            {
                result.Message = CustomErrorCode.BP_ROLE_EXIST_SPECIAL_CHARS_NAME;
                result.CustomError = string.Format(CustomErrorMessage.BP_ROLE_EXIST_SPECIAL_CHARS_NAME, updatedRole.RoleName);
                return result;
            }

            if (!string.IsNullOrEmpty(updatedRole.Description) && BluePrintUtility.CheckSpecialCharacter(updatedRole.Description.Trim()))
            {
                result.Message = CustomErrorCode.BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION;
                result.CustomError = string.Format(CustomErrorMessage.BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION);
                return result;
            }

            if (!string.IsNullOrEmpty(updatedRole.RoleName))
                existedRole.Name = updatedRole.RoleName;

            if (!string.IsNullOrEmpty(updatedRole.Description))
                existedRole.Description = updatedRole.Description;

            existedRole.UpdatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : CommonConstant.ADMIN;
            existedRole.UpdatedDate = DateTime.UtcNow;

            if (updatedRole.Permissions != null && updatedRole.Permissions.Count > 0)
            {
                GetSelectedPermissions(updatedRole.Permissions, ref existedRole);
            }

            try
            {
                var resultUpdated = _unitOfWork.RoleRepository.UpdateAsync(existedRole).Result;
                result = UpdateRoleDtoInfo(resultUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateGroup() error: { ex.ToString()}");
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_UPDATED_FAIL, existedRole.Name);
                result.CustomError = CustomErrorCode.BP_ROLE_UPDATED_FAIL;
                return result;
            }

            return result;
        }

        public async Task<RoleDto> DeleteRole(RoleDto deletedRole)
        {
            var result = new RoleDto();

            var existedRole = await _unitOfWork.RoleRepository.Query().
                Include(x => x.RoleGroups)
                .ThenInclude(a => a.Group)
                .FirstOrDefaultAsync(x => x.Id == deletedRole.RoleId);

            if (existedRole is null || existedRole.Status.Equals(nameof(RoleStatus.Removed)))
            {
                result.CustomError = CustomErrorCode.BP_ROLE_NOT_FOUND;
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_NOT_FOUND, deletedRole.RoleId);
                return result;
            }

            var isAnyGroupActive = existedRole.RoleGroups.Any(x => x.Group.Status == nameof(GroupStatus.Active));
            if (isAnyGroupActive)
            {
                _logger.LogError($"Delete Role {deletedRole.RoleId} have some groups are Active");
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_REMOVED_FAIL_GROUP_ACTIVE, existedRole.Name);
                result.CustomError = CustomErrorCode.BP_ROLE_REMOVED_FAIL;
                return result;
            }

            existedRole.UpdatedDate = DateTime.UtcNow;
            existedRole.Status = nameof(RoleStatus.Removed);

            try
            {
                var resultUpdated = await _unitOfWork.RoleRepository.UpdateAsync(existedRole);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteRole() error: { ex}");
                result.Message = string.Format(CustomErrorMessage.BP_ROLE_REMOVED_FAIL, existedRole.Name);
                result.CustomError = CustomErrorCode.BP_ROLE_REMOVED_FAIL;
                return result;
            }

            return result;
        }


        #region private functions

        private RoleDto AddRolePermissions(IList<string> selectedPermissions, Role existedRole, RoleRequest roleRequest)
        {
            var result = new RoleDto();
            try
            {
                existedRole.RolePermissions = new List<RolePermission>();
                foreach (var item in selectedPermissions)
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = existedRole.Id,
                        PermissionId = int.Parse(item),
                        BelongToRole = false
                    };

                    existedRole.RolePermissions.Add(rolePermission);
                }

                if (roleRequest.Equals(RoleRequest.Update))
                {
                    existedRole.UpdatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : CommonConstant.ADMIN;
                    existedRole.UpdatedDate = DateTime.UtcNow;
                }

                var updateRolePermissions = _unitOfWork.RoleRepository.UpdateAsync(existedRole).Result;
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Message = string.Format(CustomErrorCode.BP_ROLE_ADD_PERMISSION_FAIL, existedRole.Name);
                result.CustomError = CustomErrorCode.BP_ROLE_ADD_PERMISSION_FAIL;
                return result;
            }

            return result;
        }

        private async Task<bool> CheckExistedRoleInDB(RoleDto roleObj, string roleStatus, string action)
        {
            if (string.IsNullOrEmpty(roleObj.RoleName))
            {
                return false;
            }

            //Check existed role in database or not
            if (action.Equals(nameof(RoleRequest.Create)))
            {
                var existedRole = await _roleRepository.Query().FirstOrDefaultAsync(x => x.Name.Equals(roleObj.RoleName.Trim())
                && x.Status.Equals(roleStatus));
                if (existedRole != null)
                    return true;
            }

            if (action.Equals(nameof(RoleRequest.Update)))
            {
                var existedRole = await _roleRepository.Query().FirstOrDefaultAsync(x => x.Name.Equals(roleObj.RoleName.Trim())
                && x.Status.Equals(roleStatus));
                if (existedRole != null && roleObj.RoleId != existedRole.Id)
                    return true;
            }

            return false;
        }

        private async Task<bool> CheckExistedPermisionInDB(int permissionId)
        {
            //Check existed permission in database or not?           
            var existedPermission = await _unitOfWork.PermissionRepository.Query().FirstOrDefaultAsync(x => x.Id == permissionId);
            if (existedPermission != null)
                return true;

            return false;
        }

        //private bool CheckValidSelectedPermission(IList<RolePermission> currentRolePermissions, int addRoleID)
        //{
        //    bool result = false;
        //    if (currentRolePermissions != null && currentRolePermissions.Count > 0)
        //    {
        //        foreach (var role in currentRolePermissions)
        //        {
        //            if (addRoleID == role.RoleId)
        //            {
        //                result = true;
        //                break;
        //            }
        //        }
        //    }
        //    return result;
        //}

        private void GetSelectedPermissions(IList<string> selectedPermissions, ref Role existedRole)
        {
            // Set all permission of existed role is false
            existedRole.RolePermissions = existedRole.RolePermissions.Select(c => { c.BelongToRole = false; return c; }).ToList();

            // Set selected Permision on existed role is true
            existedRole.RolePermissions = existedRole.RolePermissions.Select(c => { if (selectedPermissions.Contains(c.PermissionId.ToString())) { c.BelongToRole = true; } else { c.BelongToRole = false; } return c; }).ToList();
        }

        private async Task<Role> GetExistedRoleInDB(string roleName)
        {
            var result = await _roleRepository.Query().Include(b => b.RolePermissions).FirstOrDefaultAsync(x => x.Name.Equals(roleName.Trim()));

            if (result != null)
            {
                return result;
            }

            return null;
        }

        private IList<string> GetExistedPermissions(ICollection<RolePermission> existedPermissions, int currentRoleId)
        {
            IList<string> permissionList = new List<string>();

            if (existedPermissions != null && existedPermissions.Count > 0)
            {
                foreach (var permiss in existedPermissions)
                {
                    if (permiss.RoleId == currentRoleId)
                    {
                        permissionList.Add(permiss.PermissionId.ToString());
                    }
                }
            }

            return permissionList;
        }

        private IList<string> GetExistedGroups(ICollection<RoleGroup> existedGroups, int currentRoleId)
        {
            IList<string> groupList = new List<string>();

            if (existedGroups != null && existedGroups.Count > 0)
            {
                foreach (var group in existedGroups)
                {
                    if (group.RoleId == currentRoleId)
                    {
                        groupList.Add(group.RoleId.ToString());
                    }
                }
            }

            return groupList;
        }

        private RoleDto UpdateRoleDtoInfo(Role roleEntity)
        {
            if (roleEntity is null) return null;

            var roleDTO = new RoleDto()
            {
                RoleId = roleEntity.Id,
                RoleName = roleEntity.Name,
                Description = roleEntity.Description,
                CreatedDate = roleEntity.CreatedDate,
                UpdatedDate = roleEntity.UpdatedDate,
                Permissions = GetExistedPermissions(roleEntity.RolePermissions, roleEntity.Id),
                Status = roleEntity.Status
            };

            return roleDTO;
        }

        #endregion
    }
}
