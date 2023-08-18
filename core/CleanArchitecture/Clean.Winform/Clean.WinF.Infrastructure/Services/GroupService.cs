//using Clean.WinF.Domain.Entities.Users;
//using Clean.WinF.Domain.IServices;
//using Clean.WinF.Domain.Models;
//using Clean.WinF.Domain.Repository;
//using Clean.WinF.Infrastructure.Utilities;
//using Clean.WinF.Shared.Constants;
//using Clean.WinF.Shared.DTOs.Email;
//using Clean.WinF.Shared.DTOs.LDAP;
//using Clean.WinF.Shared.DTOs.Users;
//using Clean.WinF.Shared.Enums;
//using Clean.WinF.Shared.ErrorMessage;
//using Clean.WinF.Shared.ErrorMessage.HttpRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Services
{
    public class GroupService : IGroupService
    {
        private readonly IConfiguration _config;
        private readonly IAsyncRepository<DistributionList> _distributionRepository;
        private readonly IAsyncRepository<DistributionListGroup> _distributionListGroupRepository;
        private readonly IAsyncRepository<Group> _groupRepository;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly ILogger<GroupService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILdapService _ldap;
        private readonly IAccountService _accountService;

        public GroupService(IAsyncRepository<Group> groupRepository,
                            IAsyncRepository<User> userRepository,
                            IAsyncRepository<Role> roleRepository,
                            IAsyncRepository<DistributionList> distributionListRepository,
                            IAsyncRepository<DistributionListGroup> distributionListGroupRepository,
                            ILogger<GroupService> logger,
                            ILdapService ldap,
                            IAccountService accountService,
                            IConfiguration config, IUnitOfWork unitOfWork)

        {
            _config = config;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _distributionRepository = distributionListRepository;
            _distributionListGroupRepository = distributionListGroupRepository;
            _logger = logger;
            _ldap = ldap;
            _accountService = accountService;
            _unitOfWork = unitOfWork;
        }

        public async Task<GroupDto> CreateNewGroup(GroupDto addGroup)
        {
            var result = new GroupDto();
            string errMsg = string.Empty;


            var existedGroup = await CheckExistedGroupInDB(addGroup.GroupName, GroupRequest.CreateNew);
            if (existedGroup != null && !string.IsNullOrEmpty(existedGroup.CustomError))
            {
                result.Message = existedGroup.Message;
                result.CustomError = existedGroup.CustomError;
                return result;
            }

            //check special characters for group name and description
            if (!string.IsNullOrEmpty(addGroup.GroupName) && BluePrintUtility.CheckSpecialCharacter(addGroup.GroupName.Trim()))
            {
                result.Message = CustomErrorCode.BP_GROUP_EXIST_SPECIAL_CHARS_NAME;
                result.CustomError = string.Format(CustomErrorMessage.BP_GROUP_EXIST_SPECIAL_CHARS_NAME, addGroup.GroupName);
                return result;
            }

            if (!string.IsNullOrEmpty(addGroup.Description) && BluePrintUtility.CheckSpecialCharacter(addGroup.Description.Trim()))
            {
                result.Message = CustomErrorCode.BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION;
                result.CustomError = string.Format(CustomErrorMessage.BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION);
                return result;
            }

            //add new to db
            var newGroup = new Group()
            {
                GroupId = addGroup.GroupId,
                Name = addGroup.GroupName.Trim(),
                CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config),
                CreatedDate = DateTime.UtcNow,
                Description = !string.IsNullOrEmpty(addGroup.Description) ? addGroup.Description.Trim() : string.Empty,
                Status = nameof(GroupStatus.Active)
            };

            try
            {
                var groupDtoResult = await _unitOfWork.GroupRepository.AddAsync(newGroup);
                _unitOfWork.Complete();
                var groupresult = await _unitOfWork.GroupRepository.Query().FirstOrDefaultAsync(b => b.Name.Equals(newGroup.Name)
                && b.Status.Equals(nameof(GroupStatus.Active)));
                addGroup.GroupId = groupresult.GroupId;
                addGroup.Status = groupDtoResult.Status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                result.Message = ex.Message;
                result.CustomError = CustomErrorCode.BP_INTERNAL_USER_CREATE_FAIL;
                return result;
            }

            return addGroup;
        }

        public async Task<GroupDto> AddSelectedUsersToGroup(GroupDto group, AddUsersDistributionListGroupRequest addUserDistributionList)
        {
            var result = new GroupDto();

            try
            {
                //check existed db           
                var existedGroup = _unitOfWork.GroupRepository.Query()
                                            .Include(b => b.UserGroups)
                                            .Include(dg => dg.DistributionListGroups).FirstOrDefault(x => x.GroupId == group.GroupId);

                if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
                {
                    result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, group.GroupName);
                    result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                    return result;
                }

                if (addUserDistributionList.LDAPUsers is null && addUserDistributionList.DistributionLists is null)
                {
                    result.Message = CustomErrorMessage.BP_USER_GROUP_EMPTY;
                    result.CustomError = CustomErrorCode.BP_USER_GROUP_EMPTY;
                    return result;
                }

                // add Ldap users to group
                if (addUserDistributionList.LDAPUsers != null && addUserDistributionList.LDAPUsers.Count > 0)
                {
                    result = ValidateLDAPUsers(group.GroupId, addUserDistributionList.LDAPUsers, GroupRequest.Update).Result;
                    if (result != null && !string.IsNullOrEmpty(result.CustomError))
                    {
                        return result;
                    }

                    existedGroup.UserGroups = GetSelectedUsers(result.Users, existedGroup, UserGroupAction.Add) as ICollection<UserGroup>;
                }

                //add distribution list to group
                if (addUserDistributionList.DistributionLists != null && addUserDistributionList.DistributionLists.Count > 0)
                {
                    result = ValidateLDAPDistributionLists(existedGroup.GroupId, addUserDistributionList.DistributionLists, GroupRequest.Update).Result;
                    if (result != null && !string.IsNullOrEmpty(result.CustomError))
                    {
                        return result;
                    }

                    existedGroup.DistributionListGroups = GetSelectedDistributionLists(result.DistributionLists, existedGroup, UserGroupAction.Add) as ICollection<DistributionListGroup>;
                }

                existedGroup.ModifiedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config);
                existedGroup.ModifiedDate = DateTime.UtcNow;
                result = UpdateExistingGroup(existedGroup, result.Users, null, result.DistributionLists).Result;
                if (result != null && !string.IsNullOrEmpty(result.CustomError))
                    return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result.CustomError = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = HttpRequestErrorMessage.HttpRequestErr500;
                return result;
            }

            return result;
        }

        public async Task<GroupDto> AddSelectedRolesToGroup(GroupDto group, IList<string> selectedRoles)
        {
            var result = new GroupDto();

            //check existed db
            var existedGroup = await _unitOfWork.GroupRepository.Query().Include(b => b.RoleGroups).SingleOrDefaultAsync(p => p.GroupId == group.GroupId);
            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, group.GroupName);
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                return result;
            }

            //validate selected roles
            result = ValidateSelectedRoles(selectedRoles, GroupRequest.Update).Result;
            if (result != null && !string.IsNullOrEmpty(result.CustomError))
                return result;

            var selectedShortRole = new List<ShortRoleDto>();
            foreach (var role in selectedRoles)
            {
                if (int.TryParse(role, out int roleId))
                {
                    var addRole = new ShortRoleDto()
                    {
                        Id = roleId
                    };
                    selectedShortRole.Add(addRole);
                }
            }

            existedGroup.RoleGroups = GetSelectedRoles(selectedShortRole, existedGroup, RoleGroupAction.Add) as ICollection<RoleGroup>;
            existedGroup.ModifiedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config);
            existedGroup.ModifiedDate = DateTime.UtcNow;

            result = await UpdateExistingGroup(existedGroup, null, selectedShortRole, null);

            return result;
        }

        public async Task<GroupDto> GetGroupById(int groupId)
        {
            var result = new GroupDto();
            string errMsg = string.Empty;

            //check existed db
            var existedGroup = await _groupRepository.Query().Include(b => b.UserGroups).Include(dl => dl.DistributionListGroups).Include(x => x.RoleGroups).FirstOrDefaultAsync(p => p.GroupId == groupId);
            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupId);
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                return result;
            }

            result.GroupId = existedGroup.GroupId;
            result.GroupName = existedGroup.Name;
            result.CreatedBy = existedGroup.CreatedBy;
            result.CreatedDate = existedGroup.CreatedDate;
            result.Description = existedGroup.Description;
            result.ModifiedBy = existedGroup.ModifiedBy;
            result.ModifiedDate = existedGroup.ModifiedDate;
            result.Status = existedGroup.Status;
            result.Users = GetExistedUsers(existedGroup.UserGroups, existedGroup.GroupId);
            result.DistributionLists = GetExistedDistributionLists(existedGroup.DistributionListGroups, existedGroup.GroupId);
            result.Roles = GetExistedRoles(existedGroup.RoleGroups, existedGroup.GroupId);

            return result;
        }

        public async Task<IEnumerable<GroupDto>> ListAllGroupsAsync()
        {
            IList<GroupDto> groupList = new List<GroupDto>();
            string activeStatus = nameof(GroupStatus.Active);

            var groups = _groupRepository.Query()
                .Include(g => g.UserGroups)
                .ThenInclude(ug => ug.Users)
                .Include(g => g.RoleGroups)
                .ThenInclude(rg => rg.Roles)
                .Where(g => g.Status.Equals(activeStatus))
                .ToList();

            if (groups.Count == 0) return null;

            foreach (var group in groups)
            {
                groupList.Add(new GroupDto
                {
                    GroupId = group.GroupId,
                    GroupName = group.Name,
                    Description = group.Description,
                    ModifiedDate = group.ModifiedDate,
                    CreatedBy = group.CreatedBy,
                    CreatedDate = group.CreatedDate,
                    Status = group.Status,
                    Roles = group.RoleGroups.Select(rg => rg.Roles).Select(r => new ShortRoleDto { Id = r.Id, DisplayName = r.Name }).ToList(),
                    Users = group.UserGroups.Select(ug => ug.Users).Select(u => new ShortUserDto { Id = u.Id, DisplayName = u.DisplayName }).ToList()
                });
            }

            return groupList;
        }

        public async Task<IList<GroupDto>> SearchGroupByCondition(string searchGroup)
        {
            var result = new List<GroupDto>();
            _logger.LogInformation($"Begining query all groups records =  {searchGroup}");                       

            var groupRes = _unitOfWork.GroupRepository.Query().Where(g => g.Name.Contains(searchGroup) && g.Status.Equals(nameof(GroupStatus.Active))).AsQueryable();
            if (groupRes != null && groupRes.Count() > 0)
            {
                foreach (var group in groupRes)
                {
                    var newGroup = new GroupDto()
                    {
                        GroupId = group.GroupId,
                        GroupName = group.Name,
                        Description = group.Description,
                        CreatedBy = group.CreatedBy,
                        CreatedDate = group.CreatedDate,
                        ModifiedBy = group.ModifiedBy,
                        ModifiedDate = group.ModifiedDate,
                        Status = group.Status
                    };
                    result.Add(newGroup);
                }
            }
            return result;
        }

        public async Task<GroupDto> UpdateGroup(GroupDto updatedGroup)
        {
            var result = new GroupDto();

            if(updatedGroup is null)
            {
                throw new ArgumentNullException("updatedGroup object parameter should not be null!");  
            }

            var existedGroup = await _unitOfWork.GroupRepository.Query()
                .FirstOrDefaultAsync(x => x.GroupId == updatedGroup.GroupId
                && x.Status.Equals(nameof(GroupStatus.Active)));

            if (existedGroup is null)
            {
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, updatedGroup.GroupId);
                return result;
            }

            if (string.IsNullOrEmpty(updatedGroup.GroupName))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY);
                result.CustomError = CustomErrorCode.BP_GROUP_NAME_EMPTY;
                return result;
            }

            //Currently system allow special character in name -- confirmed with team 18/04/2023 (An,Khoa)
            //if (BluePrintUtility.HasSpecialCharacters(updatedGroup.GroupName))
            //{
            //    result.Message = ErrorCode.BP_GROUP_INVALID_NAME;
            //    result.CustomError = string.Format(CustomErrorMessage.BP_GROUP_INVALID_NAME);
            //    return result;
            //}

            //check special characters for group name and description
            if (!string.IsNullOrEmpty(updatedGroup.GroupName) && BluePrintUtility.CheckSpecialCharacter(updatedGroup.GroupName.Trim()))
            {
                result.Message = CustomErrorCode.BP_GROUP_EXIST_SPECIAL_CHARS_NAME;
                result.CustomError = string.Format(CustomErrorMessage.BP_GROUP_EXIST_SPECIAL_CHARS_NAME, updatedGroup.GroupName);
                return result;
            }

            if (!string.IsNullOrEmpty(updatedGroup.Description) && BluePrintUtility.CheckSpecialCharacter(updatedGroup.Description.Trim()))
            {
                result.Message = CustomErrorCode.BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION;
                result.CustomError = string.Format(CustomErrorMessage.BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION);
                return result;
            }

            updatedGroup.GroupName = updatedGroup.GroupName.Trim();
            if (!string.IsNullOrEmpty(updatedGroup.GroupName))
            {
                var groupName = await _unitOfWork.GroupRepository.Query()
                .FirstOrDefaultAsync(x => x.Name.Equals(updatedGroup.GroupName)
                && x.Status.Equals(nameof(GroupStatus.Active)));
                if (groupName != null && groupName.GroupId != updatedGroup.GroupId)
                {
                    if (groupName.Name.Equals(updatedGroup.GroupName))
                    {
                        result.CustomError = CustomErrorCode.BP_GROUP_EXISTED_ALREADY;
                        result.Message = string.Format(CustomErrorMessage.BP_GROUP_EXISTED_ALREADY, updatedGroup.GroupName);
                        return result;
                    }
                }
                else
                {
                    existedGroup.Name = updatedGroup.GroupName;
                }
            }

            if (!string.IsNullOrEmpty(updatedGroup.Description))
                existedGroup.Description = updatedGroup.Description;

            if (!string.IsNullOrEmpty(updatedGroup.ModifiedBy))
                existedGroup.ModifiedBy = updatedGroup.ModifiedBy;

            existedGroup.ModifiedDate = DateTime.UtcNow;

            try
            {
                var resultUpdated = await _unitOfWork.GroupRepository.UpdateAsync(existedGroup);
                result = UpdateGroupDtoInfo(resultUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateGroup() error: { ex.ToString()}");
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_UPDATED_FAIL, existedGroup.Name);
                result.CustomError = CustomErrorCode.BP_GROUP_UPDATED_FAIL;
                return result;
            }

            return result;
        }

        public async Task<GroupDto> DeleteGroup(GroupDto deletedGroup)
        {
            var result = new GroupDto();

            var existedGroup = await _unitOfWork.GroupRepository.Query()
                .FirstOrDefaultAsync(x => x.GroupId == deletedGroup.GroupId);

            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, deletedGroup.GroupId);
                return result;
            }

            existedGroup.ModifiedDate = DateTime.UtcNow;
            existedGroup.Status = nameof(GroupStatus.Removed);

            try
            {
                var resultUpdated = await _unitOfWork.GroupRepository.UpdateAsync(existedGroup);
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteGroup() error: { ex.ToString()}");
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_REMOVED_FAIL, existedGroup.Name);
                result.CustomError = CustomErrorCode.BP_GROUP_REMOVED_FAIL;
                return result;
            }

            return result;
        }

        public async Task<GroupDto> RemoveUserToGroup(int groupID, int userID, string userType)
        {
            var result = new GroupDto();
            string errMsg = string.Empty;

            //check existed db
            var existedGroup = _unitOfWork.GroupRepository.Query().Include(b => b.UserGroups).Include(dg => dg.DistributionListGroups).Include(rg => rg.RoleGroups).FirstOrDefault(x => x.GroupId == groupID);
            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupID);
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                return result;
            }

            existedGroup.ModifiedBy = BluePrintUtility.GetUserNTIDFromToken(_config);
            existedGroup.ModifiedDate = DateTime.UtcNow;

            //validate selected users
            bool isDistributionList = false;
            if (userType.ToLower().Equals(nameof(RemovedUserType.User).ToLower()))
            {
                var selectedUsers = new List<ShortUserDto>();
                var shorUserInfo = new ShortUserDto() { Id = userID };
                selectedUsers.Add(shorUserInfo);

                if (!CheckExisteUserGroup(groupID, userID))
                {
                    result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
                    result.Message = string.Format("User {0} is not existed in the current group {1}", userID, groupID);
                    return result;
                }
            }
            else
            {
                isDistributionList = true;
                var existedDistribution = _distributionListGroupRepository.Query().FirstOrDefault(x => x.GroupId == groupID && x.DistributionListId == userID);
                if (existedDistribution is null)
                {
                    result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_NOT_FOUND;
                    result.Message = string.Format("Distribution list {0} is not existed in the current group {1}", userID, groupID);
                    return result;
                }
            }

            if (!isDistributionList)
            {
                var selectedShortUsers = new List<ShortUserDto>();
                var shortUserInfo = new ShortUserDto()
                {
                    Id = userID
                };
                selectedShortUsers.Add(shortUserInfo);
                existedGroup.UserGroups = GetSelectedUsers(selectedShortUsers, existedGroup, UserGroupAction.Remove) as ICollection<UserGroup>;

                result = await UpdateExistingGroup(existedGroup, selectedShortUsers, null, null);
            }
            else
            {
                var selectedShorDistributionLists = new List<ShortDistributionListDto>();
                var shortDistributionInfo = new ShortDistributionListDto()
                {
                    Id = userID
                };
                selectedShorDistributionLists.Add(shortDistributionInfo);
                existedGroup.DistributionListGroups = GetSelectedDistributionLists(selectedShorDistributionLists, existedGroup, UserGroupAction.Remove) as ICollection<DistributionListGroup>;
                result = await UpdateExistingGroup(existedGroup, null, null, selectedShorDistributionLists);
            }

            return result;
        }

        public async Task<GroupDto> RemoveRoleToGroup(int groupID, int roleId)
        {
            var result = new GroupDto();
            string errMsg = string.Empty;

            //check existed db
            var existedGroup = _unitOfWork.GroupRepository.Query().Include(b => b.RoleGroups).FirstOrDefault(x => x.GroupId == groupID);
            if (existedGroup is null
                || existedGroup.Status.Equals(nameof(GroupStatus.Removed))
                || existedGroup.Status.Equals(nameof(GroupStatus.InActive)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupID);
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                return result;
            }

            //validate selected roles            
            var selectedRoles = new List<ShortRoleDto>();
            var shortRoleInfo = new ShortRoleDto() { Id = roleId };
            selectedRoles.Add(shortRoleInfo);

            if (!CheckExistedRoleGroup(groupID, roleId))
            {
                result.CustomError = CustomErrorCode.BP_ROLE_NOT_FOUND;
                result.Message = string.Format("Role {0} is not existed in the current group {1}", roleId, groupID);
                return result;
            }

            existedGroup.RoleGroups = GetSelectedRoles(selectedRoles, existedGroup, RoleGroupAction.Remove) as ICollection<RoleGroup>;
            existedGroup.ModifiedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config);
            existedGroup.ModifiedDate = DateTime.UtcNow;

            result = await UpdateExistingGroup(existedGroup, null, selectedRoles, null);

            return result;
        }

        public async Task<GroupDto> RemoveDistributionListsToGroup(int groupID, int distribuitionListId)
        {
            var result = new GroupDto();

            //check existed db
            var existedGroup = _unitOfWork.GroupRepository.Query().Include(b => b.UserGroups).FirstOrDefault(x => x.GroupId == groupID);
            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupID);
                result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                return result;
            }

            //validate selected distribution list
            var selectedDistributionList = new List<ShortDistributionListDto>();
            var shortDistribution = new ShortDistributionListDto()
            {
                Id = distribuitionListId
            };
            selectedDistributionList.Add(shortDistribution);
            if (!CheckExistedDistributionListInGroup(groupID, distribuitionListId))
            {
                result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_NOT_FOUND;
                result.Message = CustomErrorMessage.BP_DISTRIBUTION_LIST_NOT_FOUND;
                return result;
            }

            existedGroup.DistributionListGroups = GetSelectedDistributionLists(selectedDistributionList, existedGroup, UserGroupAction.Remove) as ICollection<DistributionListGroup>;
            existedGroup.ModifiedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config);
            existedGroup.ModifiedDate = DateTime.UtcNow;

            result = await UpdateExistingGroup(existedGroup, null, null, selectedDistributionList);

            return result;
        }

        public async Task<IList<UserDto>> SearchUserInGroup(int groupId, string userName)
        {
            var result = new List<UserDto>();

            //check existed db
            var existedGroup = await _unitOfWork.GroupRepository.Query().SingleOrDefaultAsync(p => p.GroupId == groupId);
            if (existedGroup is null || existedGroup.Status.Equals(nameof(GroupStatus.Removed)))
            {
                var cusErr = new UserDto()
                {
                    Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupId),
                    CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND
                };
                result.Add(cusErr);
                return result;
            }

            if (!string.IsNullOrEmpty(userName))
            {
                var listUsers = _unitOfWork.UserRepository.Query().Include(ug => ug.UserGroups).Where(p => p.UserName.Contains(userName) || p.FullName.Contains(userName)).AsQueryable();
                if (listUsers != null && listUsers.Count() > 0)
                {
                    foreach (var user in listUsers)
                    {
                        if (user.Status.Equals(nameof(UserStatus.Active)) && user.UserGroups != null && user.UserGroups.Count > 0)
                        {
                            foreach (var exitedUser in user.UserGroups)
                            {
                                if (exitedUser.GroupId == groupId)
                                {
                                    var userDtoRet = new UserDto()
                                    {
                                        Id = user.Id,
                                        UserName = user.UserName,
                                        Email = user.Email,
                                        CreatedDate = user.CreatedDate,
                                        LastActive = user.LastActive,
                                        Status = user.Status
                                    };
                                    result.Add(userDtoRet);
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var listDistributions = _distributionRepository.Query().Include(dg => dg.DistributionListGroups).Where(p => p.Name.Contains(userName) || p.Description.Contains(userName)).AsQueryable();
                    if (listDistributions != null && listDistributions.Count() > 0)
                    {
                        foreach (var distribution in listDistributions)
                        {
                            if (distribution.Status.Equals(nameof(UserStatus.Active)) && distribution.DistributionListGroups != null && distribution.DistributionListGroups.Count > 0)
                            {
                                foreach (var existedDis in distribution.DistributionListGroups)
                                {
                                    if (existedDis.GroupId == groupId)
                                    {
                                        var userDtoRet = new UserDto()
                                        {
                                            Id = distribution.Id,
                                            DisplayName = distribution.Name,
                                            Email = distribution.Email,
                                            Status = distribution.Status,
                                            CreatedDate = distribution.CreatedDate,
                                            LastActive = distribution.UpdatedDate
                                        };
                                        result.Add(userDtoRet);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        #region private functions

        private GroupDto UpdateGroupDtoInfo(Group groupEntity)
        {
            if (groupEntity is null) return null;

            var groupDTO = new GroupDto()
            {
                GroupId = groupEntity.GroupId,
                GroupName = groupEntity.Name,
                Description = groupEntity.Description,
                CreatedBy = groupEntity.CreatedBy,
                CreatedDate = groupEntity.CreatedDate,
                ModifiedBy = groupEntity.ModifiedBy,
                ModifiedDate = groupEntity.ModifiedDate,
                Status = groupEntity.Status
                //RoleGroups = GetExistedRoles(groupEntity.RoleGroups, groupEntity.GroupId),
                //UserGroups = GetExistedUsers(groupEntity.UserGroups, groupEntity.GroupId)
            };

            return groupDTO;
        }

        private async Task<GroupDto> ValidateSelectedUsers(int groupID, IList<string> selectedUsers, GroupRequest request)
        {
            var result = new GroupDto();
            IList<ShortUserDto> resultUsers = new List<ShortUserDto>();

            if (selectedUsers != null && selectedUsers.Count > 0)
            {
                for (int i = 0; i < selectedUsers.Count; i++)
                {
                    if (int.TryParse(selectedUsers[i], out int userID))
                    {
                        var existedUser = await _userRepository.GetByIdAsync(userID);
                        if (!CheckExisteUserGroup(groupID, userID))
                        {
                            if (existedUser is null)
                            {
                                result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
                                result.Message = string.Format(CustomErrorMessage.BP_USER_NOT_FOUND, selectedUsers[i]);
                                return result;
                            }

                            int.TryParse(selectedUsers[i], out int IdValue);
                            var shortUserDto = new ShortUserDto()
                            {
                                Id = IdValue
                            };
                            resultUsers.Add(shortUserDto);
                            if (resultUsers != null && resultUsers.Count > 0)
                            {
                                var statusResult = UpdateActiveStatusAndSendEmailToSelectedUsers(resultUsers);
                                if (statusResult != null && !string.IsNullOrEmpty(statusResult.CustomError))
                                {
                                    result.CustomError = statusResult.CustomError;
                                    result.Message = statusResult.Message;
                                    return result;
                                }
                            }
                        }
                        else
                        {
                            result.CustomError = CustomErrorCode.BP_USER_GROUP_EXISTED_ALREADY;
                            result.Message = string.Format(CustomErrorMessage.BP_USER_GROUP_EXISTED_ALREADY, existedUser.UserName);
                            return result;
                        }
                    }
                    else
                    {
                        result.CustomError = CustomErrorCode.BP_USER_GROUP_ID_VALUE;
                        result.Message = CustomErrorMessage.BP_USER_GROUP_ID_VALUE;
                        return result;
                    }
                }
            }

            if (resultUsers.Count > 0)
                result.Users = resultUsers;
            else
                result.Users = null;

            return result;
        }

        private async Task<GroupDto> ValidateLDAPUsers(int groupId, IList<LdapDto> LDAPUsers, GroupRequest request)
        {
            var result = new GroupDto();
            IList<ShortUserDto> resultUsers = new List<ShortUserDto>();

            if (LDAPUsers != null && LDAPUsers.Count > 0)
            {
                for (int i = 0; i < LDAPUsers.Count; i++)
                {
                    if (string.IsNullOrEmpty(LDAPUsers[i].UserId))
                    {
                        result.CustomError = CustomErrorCode.BP_USER_INVALID_NAME;
                        result.Message = string.Format(CustomErrorMessage.BP_USER_INVALID_NAME, LDAPUsers[i].DisplayName);
                        return result;
                    }

                    if (LDAPUsers[i] != null)
                    {
                        //email should be not empty
                        if (string.IsNullOrEmpty(LDAPUsers[i].Email))
                        {
                            result.CustomError = CustomErrorCode.BP_USER_EMAIL_EMPTY;
                            result.Message = string.Format(CustomErrorMessage.BP_USER_EMAIL_EMPTY, LDAPUsers[i].UserId.Trim());
                            return result;
                        }

                        //valid email address again
                        if (!BluePrintUtility.IsValidEmailAddress(LDAPUsers[i].Email))
                        {
                            result.CustomError = CustomErrorCode.BP_USER_EMAIL_INVALID;
                            result.Message = string.Format(CustomErrorMessage.BP_USER_EMAIL_INVALID, LDAPUsers[i].UserId.Trim());
                            return result;
                        }

                        var existedDBUser = _userRepository.Query().SingleOrDefault(p => p.UserName.Equals(LDAPUsers[i].UserId.Trim()));
                        if (existedDBUser is null)
                        {
                            //validation user by check ldap again
                            var existedLapUser = _ldap.FindByUserId(LDAPUsers[i].UserId.Trim());
                            if (existedLapUser is null)
                            {
                                result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
                                result.Message = string.Format(CustomErrorMessage.BP_USER_NOT_FOUND, LDAPUsers[i].UserId.Trim());
                                return result;
                            }

                            //begin add new LDAP user into db
                            var newLDAPUser = new User()
                            {
                                City = LDAPUsers[i].City,
                                Country = LDAPUsers[i].Country,
                                DisplayName = LDAPUsers[i].DisplayName,
                                UserName = LDAPUsers[i].UserId.Trim(),
                                FullName = !string.IsNullOrEmpty(LDAPUsers[i].DisplayName) ? BluePrintUtility.GetFullNameAndDepartmentFromLDAPUser(LDAPUsers[i].DisplayName, false) : string.Empty,
                                Department = !string.IsNullOrEmpty(LDAPUsers[i].DisplayName) ? BluePrintUtility.GetFullNameAndDepartmentFromLDAPUser(LDAPUsers[i].DisplayName, true) : string.Empty,
                                Email = LDAPUsers[i].Email,
                                PhoneNumber = LDAPUsers[i].PhoneNumber,
                                CreatedDate = DateTime.UtcNow,
                                CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config),
                                Status = nameof(UserStatus.Active)
                            };

                            var addUserResult = new UserDto();
                            try
                            {
                                addUserResult = await AddLDAPUserToDB(newLDAPUser);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.ToString());
                                result.CustomError = CustomErrorCode.BP_LDAP_USER_CREATE_FAIL;
                                result.Message = string.Format(CustomErrorMessage.BP_LDAP_USER_CREATE_FAIL, LDAPUsers[i].UserId.Trim());
                                return result;
                            }

                            if (addUserResult != null)
                            {
                                if (addUserResult.Id > 0)
                                {
                                    //send the email to users
                                    var emailInfo = new EmailDto()
                                    {
                                        Host = _config["EmailSetting:EmailSmtpHost"],
                                        Sender = _config["EmailSetting:EmailSender"],
                                        UserNTID = newLDAPUser.UserName,
                                        Subject = string.Concat("[BlueprintDotNet] - Approved user: ", newLDAPUser.UserName, " to access the system."),
                                        EmailReceiver = newLDAPUser.Email,
                                        EmailFileTemplate = Environment.CurrentDirectory + "/SendEmail/response-users-template.html",
                                        Reason = "Approved the right to access to Blueprint system"
                                    };

                                    BluePrintUtility.SendEmailInBosch(_logger, emailInfo, Boolean.Parse(_config["EmailSetting:AutoSending"]));
                                    var shortUserInfo = new ShortUserDto()
                                    {
                                        Id = addUserResult.Id
                                    };
                                    resultUsers.Add(shortUserInfo);
                                }
                            }
                        }
                        else
                        {
                            //update existed user is active
                            existedDBUser.Status = nameof(UserStatus.Active);
                            var existedUser = await _userRepository.UpdateAsync(existedDBUser);
                            var shortUserInfo = new ShortUserDto()
                            {
                                Id = existedUser.Id
                            };
                            resultUsers.Add(shortUserInfo);
                        }
                    }
                }
            }

            if (resultUsers.Count > 0)
                result.Users = resultUsers;
            else
                result.Users = null;

            return result;
        }

        private async Task<GroupDto> ValidateLDAPDistributionLists(int groupID, IList<LdapDto> ldapDistributionLists, GroupRequest request)
        {
            var result = new GroupDto();
            IList<ShortDistributionListDto> distributionLists = new List<ShortDistributionListDto>();

            if (ldapDistributionLists != null && ldapDistributionLists.Count > 0)
            {
                for (int i = 0; i < ldapDistributionLists.Count; i++)
                {
                    if (string.IsNullOrEmpty(ldapDistributionLists[i].DisplayName))
                    {
                        result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_NAME_EMPTY;
                        result.Message = CustomErrorMessage.BP_DISTRIBUTION_LIST_NAME_EMPTY;
                        return result;
                    }

                    if (ldapDistributionLists[i] != null)
                    {
                        //Email of distribution list should be not empty.
                        if (string.IsNullOrEmpty(ldapDistributionLists[i].Email))
                        {
                            result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_EMAIL_EMPTY;
                            result.Message = string.Format(CustomErrorMessage.BP_DISTRIBUTION_LIST_EMAIL_EMPTY, ldapDistributionLists[i].DisplayName);
                            return result;
                        }

                        if (!BluePrintUtility.IsValidEmailAddress(ldapDistributionLists[i].Email))
                        {
                            result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_EMAIL_INVALID;
                            result.Message = string.Format(CustomErrorMessage.BP_DISTRIBUTION_LIST_EMAIL_INVALID, ldapDistributionLists[i].DisplayName);
                            return result;
                        }

                        var existedDistributionList = _distributionRepository.Query().SingleOrDefault(p => p.Name.Equals(ldapDistributionLists[i].DisplayName.Trim()));
                        if (existedDistributionList is null)
                        {
                            //Validate the name of distribution is correct or not?
                            var distributionListsRes = _ldap.SearchDistributionList(ldapDistributionLists[i].DisplayName.Trim());
                            if (distributionListsRes is null || distributionListsRes.Count == 0)
                            {
                                result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_NOT_FOUND;
                                result.Message = CustomErrorMessage.BP_DISTRIBUTION_LIST_NOT_FOUND;
                                return result;
                            }

                            //begin add new DistributionList into db
                            int parentID = 0;
                            var newDistributionList = GetDistributionListObject(ldapDistributionLists[i].DisplayName.Trim(), ldapDistributionLists[i].Email, parentID);

                            try
                            {
                                await AddLDAPDistributionListToDB(newDistributionList);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.ToString());
                                result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_ADD_FAIL;
                                result.Message = string.Format(CustomErrorMessage.BP_DISTRIBUTION_LIST_ADD_FAIL, ldapDistributionLists[i].DisplayName.Trim());
                                return result;
                            }

                            var subjectDis = string.Concat("[Blueprint] - Approved group: ", ldapDistributionLists[i].DisplayName.Trim(), " to access the system.");
                            var distributionTemplate = Environment.CurrentDirectory + "/SendEmail/response-distribution-list-template.html";
                            var emailDistributionList = GetDistributionListEmail(ldapDistributionLists[i].DisplayName.Trim(), ldapDistributionLists[i].Email, subjectDis, distributionTemplate);
                            BluePrintUtility.SendEmailInBosch(_logger, emailDistributionList, Boolean.Parse(_config["EmailSetting:AutoSending"]));

                            parentID = GetDistributionListId(ldapDistributionLists[i].DisplayName);

                            //for add distribution
                            var shortDistribution = new ShortDistributionListDto()
                            {
                                Id = parentID,
                                DisplayName = ldapDistributionLists[i].DisplayName.Trim()
                            };
                            distributionLists.Add(shortDistribution);
                        }
                        else
                        {
                            if (!CheckExistedDistributionListInGroup(groupID, existedDistributionList.Id))
                            {

                                //for add distribution
                                var shortDistribution = new ShortDistributionListDto()
                                {
                                    Id = existedDistributionList.Id,
                                    DisplayName = ldapDistributionLists[i].DisplayName.Trim()
                                };
                                distributionLists.Add(shortDistribution);
                            }
                            else
                            {
                                result.CustomError = CustomErrorCode.BP_DISTRIBUTION_LIST_EXISTED_ALREADY;
                                result.Message = string.Format(CustomErrorMessage.BP_DISTRIBUTION_LIST_EXISTED_ALREADY, ldapDistributionLists[i].DisplayName.Trim());
                                return result;
                            }
                        }
                    }
                }

                result.DistributionLists = distributionLists;
            }

            return result;
        }

        private DistributionList GetDistributionListObject(string Name, string Email, int parentID)
        {
            var distributionListObj = new DistributionList()
            {
                Name = Name,
                Email = Email,
                ParentId = parentID,
                CreatedDate = DateTime.UtcNow,
                CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config),
                Status = nameof(UserStatus.Active)
            };
            return distributionListObj;
        }

        private async Task<GroupDto> ValidateSelectedRoles(IList<string> selectedRoles, GroupRequest request)
        {
            var result = new GroupDto();
            IList<ShortRoleDto> resultRoles = new List<ShortRoleDto>();
            if (selectedRoles != null && selectedRoles.Count > 0)
            {
                for (int i = 0; i < selectedRoles.Count; i++)
                {
                    if (int.TryParse(selectedRoles[i], out int roleId))
                    {
                        var existedRole = _roleRepository.GetByIdAsync(roleId).Result;
                        if (existedRole is null)
                        {
                            result.CustomError = CustomErrorCode.BP_ROLE_NOT_FOUND;
                            result.Message = string.Format(CustomErrorMessage.BP_ROLE_NOT_FOUND, selectedRoles[i]);
                            return result;
                        }
                        var roleEntity = new ShortRoleDto()
                        {
                            Id = roleId,
                            DisplayName = existedRole.Name
                        };
                        resultRoles.Add(roleEntity);
                    }
                }
            }

            if (resultRoles.Count > 0)
                result.Roles = resultRoles;
            else
                result.Roles = null;

            if (request.Equals(GroupRequest.Update) && result.Roles is null)
            {
                result.CustomError = CustomErrorCode.BP_ROLE_GROUP_EMPTY;
                result.Message = CustomErrorMessage.BP_ROLE_GROUP_EMPTY;
                return result;
            }

            return result;
        }

        private ICollection<UserGroup> GetSelectedUsers(IList<ShortUserDto> selectedUsers, Group existedGroup, UserGroupAction action)
        {
            IList<UserGroup> userGroups = new List<UserGroup>();

            if (existedGroup.UserGroups != null && existedGroup.UserGroups.Count > 0)
            {
                foreach (var userGroup in existedGroup.UserGroups)
                {
                    var newUserGroup = new UserGroup()
                    {
                        UserId = userGroup.UserId,
                        GroupId = existedGroup.GroupId
                    };
                    userGroups.Add(newUserGroup);
                }
            }

            if (selectedUsers != null && selectedUsers.Count > 0)
            {
                if (action == UserGroupAction.Add)
                {
                    foreach (var selectedUser in selectedUsers)
                    {
                        if (!CheckValidSelectedUser(userGroups, selectedUser.Id))
                        {
                            var newUserGroup = new UserGroup()
                            {
                                UserId = selectedUser.Id,
                                GroupId = existedGroup.GroupId
                            };
                            userGroups.Add(newUserGroup);
                        }
                    }
                }

                if (action == UserGroupAction.Remove)
                {
                    if (selectedUsers != null && selectedUsers.Count > 0)
                    {
                        bool isExistedUserGroup = false;
                        int elementIdex = 0;
                        foreach (var removeUser in userGroups)
                        {
                            if (removeUser.UserId == selectedUsers[0].Id)
                            {
                                isExistedUserGroup = true;
                                break;
                            }
                            elementIdex++;
                        }

                        if (isExistedUserGroup)
                        {
                            userGroups.RemoveAt(elementIdex);
                        }
                    }
                }
            }

            return userGroups;
        }

        private ICollection<DistributionListGroup> GetSelectedDistributionLists(IList<ShortDistributionListDto> distributionLists, Group existedGroup, UserGroupAction action)
        {
            IList<DistributionListGroup> distributionListGroups = new List<DistributionListGroup>();

            if (existedGroup.DistributionListGroups != null && existedGroup.DistributionListGroups.Count > 0)
            {
                foreach (var distributionList in existedGroup.DistributionListGroups)
                {
                    var newDistributionListGroup = new DistributionListGroup()
                    {
                        DistributionListId = distributionList.DistributionListId,
                        GroupId = existedGroup.GroupId
                    };
                    distributionListGroups.Add(newDistributionListGroup);
                }
            }

            if (distributionLists != null && distributionLists.Count > 0)
            {
                if (action == UserGroupAction.Add)
                {
                    foreach (var distributionList in distributionLists)
                    {
                        var newDistributionListGroup = new DistributionListGroup()
                        {
                            DistributionListId = distributionList.Id,
                            GroupId = existedGroup.GroupId
                        };
                        distributionListGroups.Add(newDistributionListGroup);
                    }
                }

                if (action == UserGroupAction.Remove)
                {
                    if (distributionLists != null && distributionLists.Count > 0)
                    {
                        //int.TryParse(distributionLists[0], out int distributionListsID);
                        bool isExistedUserGroup = false;
                        int elementIdex = 0;
                        foreach (var removedistributionLists in distributionListGroups)
                        {
                            if (removedistributionLists.DistributionListId == distributionLists[0].Id)
                            {
                                isExistedUserGroup = true;
                                break;
                            }
                            elementIdex++;
                        }

                        if (isExistedUserGroup)
                        {
                            distributionListGroups.RemoveAt(elementIdex);
                        }
                    }
                }
            }

            return distributionListGroups;
        }

        private bool CheckValidSelectedUser(IList<UserGroup> currentUserGroups, int addUserID)
        {
            bool result = false;
            if (currentUserGroups != null && currentUserGroups.Count > 0)
            {
                foreach (var user in currentUserGroups)
                {
                    if (addUserID == user.UserId)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private bool CheckValidSelectedRoles(IList<RoleGroup> currentRoleGroups, int addRoleID)
        {
            bool result = false;
            if (currentRoleGroups != null && currentRoleGroups.Count > 0)
            {
                foreach (var role in currentRoleGroups)
                {
                    if (addRoleID == role.RoleId)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        private ICollection<RoleGroup> GetSelectedRoles(IList<ShortRoleDto> selectedRoles, Group existedGroup, RoleGroupAction action)
        {
            IList<RoleGroup> roleGroups = new List<RoleGroup>();

            if (existedGroup.RoleGroups != null && existedGroup.RoleGroups.Count > 0)
            {
                foreach (var roleGroup in existedGroup.RoleGroups)
                {
                    var currentRoleGroup = new RoleGroup()
                    {
                        RoleId = roleGroup.RoleId,
                        GroupId = existedGroup.GroupId
                    };
                    roleGroups.Add(currentRoleGroup);
                }
            }

            if (selectedRoles != null && selectedRoles.Count > 0)
            {
                if (action == RoleGroupAction.Add)
                {
                    foreach (var selectedRole in selectedRoles)
                    {

                        if (!CheckValidSelectedRoles(roleGroups, selectedRole.Id))
                        {
                            var newRoleGroup = new RoleGroup()
                            {
                                RoleId = selectedRole.Id,
                                GroupId = existedGroup.GroupId
                            };
                            roleGroups.Add(newRoleGroup);
                        }

                    }
                }

                if (action == RoleGroupAction.Remove)
                {
                    if (selectedRoles != null && selectedRoles.Count > 0)
                    {
                        bool isExistedRoleGroup = false;
                        int elementIdex = 0;
                        foreach (var removeRole in roleGroups)
                        {
                            if (removeRole.RoleId == selectedRoles[0].Id)
                            {
                                isExistedRoleGroup = true;
                                break;
                            }
                            elementIdex++;
                        }

                        if (isExistedRoleGroup)
                        {
                            roleGroups.RemoveAt(elementIdex);
                        }
                    }
                }
            }

            return roleGroups;
        }

        private IList<ShortUserDto> GetExistedUsers(ICollection<UserGroup> existedUsers, int currentGroupId)
        {
            IList<ShortUserDto> userList = new List<ShortUserDto>();

            if (existedUsers != null && existedUsers.Count > 0)
            {
                foreach (var user in existedUsers)
                {
                    if (user.GroupId == currentGroupId)
                    {
                        var existedUser = _userRepository.GetByIdAsync(user.UserId).Result;
                        var shortUserInfor = new ShortUserDto()
                        {
                            Id = user.UserId,
                            DisplayName = existedUser != null ? existedUser.DisplayName : null
                        };
                        userList.Add(shortUserInfor);
                    }
                }
            }

            return userList;
        }

        private IList<ShortRoleDto> GetExistedRoles(ICollection<RoleGroup> existedRoles, int currentGroupId)
        {
            IList<ShortRoleDto> roleList = new List<ShortRoleDto>();

            if (existedRoles != null && existedRoles.Count > 0)
            {
                foreach (var role in existedRoles)
                {
                    if (role.GroupId == currentGroupId)
                    {
                        var roleEntity = _roleRepository.GetByIdAsync(role.RoleId).Result;
                        var shortRole = new ShortRoleDto()
                        {
                            Id = role.RoleId,
                            DisplayName = roleEntity.Name
                        };
                        roleList.Add(shortRole);
                    }
                }
            }

            return roleList;
        }

        private IList<ShortDistributionListDto> GetExistedDistributionLists(ICollection<DistributionListGroup> existedDistributionList, int groupId)
        {
            IList<ShortDistributionListDto> distributionLists = new List<ShortDistributionListDto>();

            if (existedDistributionList != null && existedDistributionList.Count > 0)
            {
                foreach (var distribution in existedDistributionList)
                {
                    if (distribution.GroupId == groupId)
                    {
                        var distributionEntity = _distributionRepository.GetByIdAsync(distribution.DistributionListId).Result;
                        if (distributionEntity != null)
                        {
                            var shortDistribution = new ShortDistributionListDto()
                            {
                                Id = distribution.DistributionListId,
                                DisplayName = distributionEntity.Name
                            };
                            distributionLists.Add(shortDistribution);
                        }
                    }
                }
            }

            return distributionLists;
        }

        private async Task<Group> CheckExistedGroupInDB(string groupName, GroupRequest request)
        {
            var result = new Group();

            if (string.IsNullOrEmpty(groupName))
            {
                result.Message = string.Format(CustomErrorMessage.BP_GROUP_NAME_EMPTY, groupName);
                result.CustomError = CustomErrorCode.BP_GROUP_NAME_EMPTY;
                return result;
            }

            //Check existed group in database or not            
            var existedGroup = await _groupRepository.Query().FirstOrDefaultAsync(x => x.Name.Equals(groupName.Trim()) &&
            x.Status.Equals(nameof(GroupStatus.Active)));
            if (request.Equals(GroupRequest.Update))
            {
                if (existedGroup is null)
                {
                    result.Message = string.Format(CustomErrorMessage.BP_GROUP_NOT_FOUND, groupName);
                    result.CustomError = CustomErrorCode.BP_GROUP_NOT_FOUND;
                    return result;
                }
                else
                {
                    if (!string.IsNullOrEmpty(existedGroup.Status) &&
                        (existedGroup.Status.Equals(nameof(GroupStatus.InActive))
                        || existedGroup.Status.Equals(nameof(GroupStatus.Removed))))
                    {
                        result.Message = string.Format(CustomErrorMessage.BP_INVALID_GROUP_STATUS, groupName);
                        result.CustomError = CustomErrorCode.BP_INVALID_GROUP_STATUS;
                        return result;
                    }
                }
            }

            if (request.Equals(GroupRequest.CreateNew))
            {
                if (existedGroup != null)
                {
                    result.Message = string.Format(CustomErrorMessage.BP_GROUP_EXISTED_ALREADY, groupName);
                    result.CustomError = CustomErrorCode.BP_GROUP_EXISTED_ALREADY;
                    return result;
                }
            }

            return existedGroup;
        }

        private async Task<GroupDto> UpdateExistingGroup(Group existedGroup, IList<ShortUserDto> selectedUsers, IList<ShortRoleDto> selectedRoles, IList<ShortDistributionListDto> selectedDistributionList)
        {
            var result = new GroupDto();
            try
            {
                var groupResult = _unitOfWork.GroupRepository.UpdateAsync(existedGroup).Result;
                result.GroupId = groupResult.GroupId;
                result.GroupName = groupResult.Name;
                result.Description = groupResult.Description;
                result.CreatedBy = BluePrintUtility.userNTIT;
                result.CreatedDate = groupResult.CreatedDate;
                result.ModifiedBy = BluePrintUtility.userNTIT;
                result.ModifiedDate = groupResult.ModifiedDate;
                result.Status = groupResult.Status;
                result.Users = existedGroup.UserGroups != null ? GetExistedUsers(existedGroup.UserGroups, result.GroupId) : selectedUsers;
                result.Roles = existedGroup.RoleGroups != null ? GetExistedRoles(existedGroup.RoleGroups, result.GroupId) : selectedRoles;
                result.DistributionLists = existedGroup.DistributionListGroups != null ? GetExistedDistributionLists(existedGroup.DistributionListGroups, result.GroupId) : selectedDistributionList;

                if (result.DistributionLists != null)
                {
                    for (int i = 0; i < result.DistributionLists.Count; i++)
                    {
                        IList<DistributionList> childGroups = _distributionRepository.Query().Where(x => x.ParentId == result.DistributionLists[i].Id).ToList();
                        if (childGroups.Count > 0)
                        {
                            result.DistributionLists[i].childGroups = new List<DistributionListDto>();
                            foreach (var childGroup in childGroups)
                            {
                                DistributionListDto distributionListDto = new DistributionListDto();
                                distributionListDto.DisplayName = childGroup.Name;
                                distributionListDto.Email = childGroup.Email;
                                distributionListDto.Country = childGroup.Country;
                                distributionListDto.City = childGroup.City;
                                result.DistributionLists[i].childGroups.Add(distributionListDto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                result.Message = ex.Message;
                result.CustomError = CustomErrorCode.BP_GROUP_UPDATED_FAIL;
                return result;
            }

            return result;
        }

        private UserDto UpdateActiveStatusAndSendEmailToSelectedUsers(IList<ShortUserDto> selectedUsers)
        {
            var result = new UserDto();

            if (selectedUsers != null && selectedUsers.Count > 0)
            {
                foreach (var user in selectedUsers)
                {
                    var userEntity = _unitOfWork.UserRepository.GetByIdAsync(user.Id).Result;
                    if (userEntity != null)
                    {
                        //update active user
                        if (userEntity.Status.Equals(nameof(UserStatus.InActive)))
                        {
                            userEntity.Status = nameof(UserStatus.Active);
                            userEntity.EmailConfirmed = true;

                            //Make sure that updating the user status cussess after that sending email
                            try
                            {
                                var updatedResult = _unitOfWork.UserRepository.UpdateAsync(userEntity);
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex.ToString());
                                result.CustomError = CustomErrorCode.BP_INTERNAL_USER_UPDATED_FAIL;
                                result.Message = string.Format(CustomErrorMessage.BP_INTERNAL_USER_UPDATED_FAIL, user.Id);
                                return result;
                            }
                        }

                        //send the email to users
                        var emailInfo = new EmailDto()
                        {
                            Host = _config["EmailSetting:EmailSmtpHost"],
                            Sender = _config["EmailSetting:EmailSender"],
                            UserNTID = userEntity.UserName,
                            Subject = string.Concat("[BlueprintDotNet] - Approved user: ", userEntity.UserName, " to access the system."),
                            EmailReceiver = userEntity.Email,
                            EmailFileTemplate = Environment.CurrentDirectory + "/SendEmail/response-users-template.html",
                            Reason = "Approved the right to access to Blueprint system"
                        };

                        var sendEmailResult = BluePrintUtility.SendEmailInBosch(_logger, emailInfo, Boolean.Parse(_config["EmailSetting:AutoSending"]));
                    }

                }
                _unitOfWork.Complete();
            }
            return result;
        }

        private bool CheckExisteUserGroup(int groupId, int userID)
        {
            bool result = true;
            var existedUser = _unitOfWork.UserGroupRepository.Query().FirstOrDefaultAsync(x => x.GroupId == groupId && x.UserId == userID).Result;
            if (existedUser is null)
            {
                result = false;
            }
            return result;
        }

        private bool CheckExistedRoleGroup(int groupId, int roleId)
        {
            bool result = true;
            var existedRole = _unitOfWork.RoleGroupRepository.Query().FirstOrDefaultAsync(x => x.GroupId == groupId && x.RoleId == roleId).Result;
            if (existedRole is null)
            {
                result = false;
            }
            return result;
        }

        private async Task<UserDto> AddLDAPUserToDB(User newLDAPUser)
        {
            var result = new UserDto();
            var addUserResult = await _unitOfWork.UserRepository.AddAsync(newLDAPUser);
            _unitOfWork.Complete();
            result = await GetLDAPUserFromDB(newLDAPUser.UserName.Trim());
            return result;
        }

        private async Task<UserDto> GetLDAPUserFromDB(string userName)
        {
            var newUserResutl = new UserDto();

            var result = _unitOfWork.UserRepository.Query().FirstOrDefault(p => p.UserName.Equals(userName.Trim()));
            if (result != null)
            {
                newUserResutl.Id = result.Id;
            }

            return newUserResutl;
        }

        private EmailDto GetDistributionListEmail(string Name, string Email, string subjectValue, string emailTemplatePath)
        {
            var emailInfo = new EmailDto()
            {
                Host = _config["EmailSetting:EmailSmtpHost"],
                Sender = _config["EmailSetting:EmailSender"],
                UserNTID = Name,
                Subject = subjectValue,
                EmailReceiver = Email,
                EmailFileTemplate = emailTemplatePath,
                Reason = "Approved the right to access to Blueprint system."
            };

            return emailInfo;
        }

        private int GetDistributionListId(string parentDistributionListName)
        {
            var parentID = 0;

            if (!string.IsNullOrEmpty(parentDistributionListName))
            {
                var result = _distributionRepository.Query().FirstOrDefaultAsync(p => p.Name.Equals(parentDistributionListName));
                if (result != null)
                    parentID = result.Result.Id;
            }

            return parentID;
        }

        private bool CheckExistedDistributionListInGroup(int groupID, int distributionListId)
        {
            var result = false;
            var existedDistribution = _distributionListGroupRepository.Query().FirstOrDefault(p => p.GroupId == groupID && p.DistributionListId == distributionListId);
            if (existedDistribution != null)
                result = true;
            return result;
        }

        private async Task<LdapDto> AddLDAPDistributionListToDB(DistributionList newLDAPDistributionList)
        {
            var result = new LdapDto();
            var addUserResult = await _distributionRepository.AddAsync(newLDAPDistributionList);
            _unitOfWork.Complete();
            if (addUserResult != null)
            {
                result.Email = addUserResult.Email;
                result.DisplayName = addUserResult.Name;
            }
            return result;
        }

        private IList<ShortUserDto> GetUserDistributionListFromGroup(int groupId, string condition)
        {
            var result = new List<ShortUserDto>();

            return result;
        }

        #endregion

    }
}
