using AutoMapper;
using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IServices;
using Clean.WinF.Domain.Repository;
using Clean.WinF.Infrastructure.Utilities;
using Clean.WinF.Shared.Constants;
using Clean.WinF.Shared.DTOs;
using Clean.WinF.Shared.DTOs.Permission;
using Clean.WinF.Shared.DTOs.Users;
using Clean.WinF.Shared.Enums;
using Clean.WinF.Shared.ErrorMessage;
using Clean.WinF.Shared.ErrorMessage.HttpRequest;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<PermissionService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionService(IConfiguration config, ILogger<PermissionService> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _config = config;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ReturnObjectDto> GetAll()
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success)
            };
            try
            {
                var permissionGroups = new List<PermissionGroupResponse>();
                foreach (var item in _unitOfWork.PermissionRepository.Query()?.ToList())
                {
                    if (item.ParentId == 0)
                    {
                        var permissionGroup = new PermissionGroupResponse
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Description = item.Description,
                            Name = item.Name,
                            Permissions = new List<PermissionResponse>()
                        };
                        permissionGroups.Add(permissionGroup);
                    }
                }

                foreach (var item in _unitOfWork.PermissionRepository.Query()?.ToList())
                {
                    var permissionGroup = permissionGroups.FirstOrDefault(x => x.Id == item.ParentId);
                    if (permissionGroup != null)
                    {
                        var permission = new PermissionResponse
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Code = item.Code,
                            ParentId = item.ParentId
                        };
                        permissionGroup.Permissions.Add(permission);
                    }
                }

                result.Data = permissionGroups;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = HttpRequestErrorMessage.HttpRequestErr500;
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnObjectDto> GetByPermissionId(int permissionId)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success),
                Data = new List<PermissionDto>()
            };
            try
            {
                var permissions = _unitOfWork.PermissionRepository.Query().Where(x => x.Id == permissionId);
                result.Data = _mapper.Map<List<PermissionDto>>(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = HttpRequestErrorMessage.HttpRequestErr500;
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnObjectDto> GetByPermissionName(string permissionName)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success),
                Data = new List<PermissionDto>()
            };
            try
            {
                var permissions = _unitOfWork.PermissionRepository.Query().Where(x => x.Name.Contains(permissionName));
                result.Data = _mapper.Map<List<PermissionDto>>(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = HttpRequestErrorMessage.HttpRequestErr500;
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnObjectDto> AddNew(PermissionDto dto)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success),
                Data = dto
            };
            try
            {
                if (string.IsNullOrEmpty(dto.Name))
                {
                    AssignValueToReturnObj(result, CustomErrorCode.BP_PERMISSION_NAME_EMPTY, CustomErrorMessage.BP_PERMISSION_NAME_EMPTY, nameof(MessageReturnType.Error), dto);
                    return await Task.FromResult(result);
                }

                var checker = await _unitOfWork.PermissionRepository.Query().FirstOrDefaultAsync(x => x.Name == dto.Name);
                if (checker != null)
                {
                    AssignValueToReturnObj(result, CustomErrorCode.BP_PERMISSION_EXISTED_ALREADY, string.Format(CustomErrorMessage.BP_PERMISSION_EXISTED_ALREADY, dto.Name), nameof(MessageReturnType.Error), dto);
                    return await Task.FromResult(result);
                }

                var permission = _mapper.Map<Permission>(dto);
                permission.Status = nameof(PermissionStatus.Active);
                permission.CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config);
                permission.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.PermissionRepository.AddAsync(permission);
                _unitOfWork.Complete();
                var permissionFromDB = _unitOfWork.PermissionRepository.Query().FirstOrDefault(x => x.Name == dto.Name);
                dto.Id = permissionFromDB.Id;
                dto.ParentId = permissionFromDB.ParentId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = string.Format(CustomErrorMessage.BP_PERMISSION_CREATE_FAIL, dto.Name);
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnObjectDto> Delete(PermissionDto dto)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success),
                Data = dto
            };
            try
            {
                var permission = await _unitOfWork.PermissionRepository.GetByIdAsync(dto.Id);
                if (permission is null)
                {
                    result.Code = CustomErrorCode.BP_PERMISSION_NOT_FOUND;
                    return await Task.FromResult(result);
                }

                permission.Status = nameof(PermissionStatus.Removed);
                await _unitOfWork.PermissionRepository.UpdateAsync(permission);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = string.Format(CustomErrorMessage.BP_PERMISSION_REMOVED_FAIL, dto.Name);
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnObjectDto> Update(PermissionDto dto)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success),
                Data = dto
            };
            try
            {
                if (string.IsNullOrEmpty(dto.Name))
                {
                    AssignValueToReturnObj(result, CustomErrorCode.BP_PERMISSION_NAME_EMPTY, CustomErrorMessage.BP_PERMISSION_NAME_EMPTY, nameof(MessageReturnType.Error), dto);
                    return await Task.FromResult(result);
                }

                if (BluePrintUtility.CheckSpecialCharacter(dto.Name))
                {
                    AssignValueToReturnObj(result, CustomErrorCode.BP_PERMISSION_INVALID_NAME, CustomErrorMessage.BP_PERMISSION_INVALID_NAME, nameof(MessageReturnType.Error), dto);
                    return await Task.FromResult(result);
                }

                var permission = await _unitOfWork.PermissionRepository.Query().AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
                if (permission is null)
                {
                    result.Code = CustomErrorCode.BP_PERMISSION_NOT_FOUND;
                    result.Message = CustomErrorCode.BP_PERMISSION_NOT_FOUND;
                    result.Status = nameof(MessageReturnType.Error);
                    AssignValueToReturnObj(result, CustomErrorCode.BP_PERMISSION_NOT_FOUND, string.Format(CustomErrorMessage.BP_PERMISSION_NOT_FOUND, dto.Name), nameof(MessageReturnType.Error), dto);
                    return await Task.FromResult(result);
                }

                permission = _mapper.Map<Permission>(dto);
                permission.UpdatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : CommonConstant.ADMIN;
                permission.UpdatedDate = DateTime.UtcNow;
                await _unitOfWork.PermissionRepository.UpdateAsync(permission);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                result.Code = CustomErrorCode.BP_INTERNAL_SERVER_ERROR;
                result.Message = HttpRequestErrorMessage.HttpRequestErr500;
                result.Status = nameof(MessageReturnType.Error);
            }
            return await Task.FromResult(result);
        }

        public async Task<string> GetIDFromViewDetailRequest(Microsoft.AspNetCore.Http.HttpContext request, string keyViewDetail)
        {
            var idValue = string.Empty;
            if (request != null)
            {
                if (request.Request.Method.Equals("GET") && !string.IsNullOrEmpty(request.Request.Path.Value))
                {
                    if (request.Request.Path.Value.Contains(keyViewDetail))
                    {
                        var arr = BluePrintUtility.ConvertStringToArray(request.Request.Path.Value, "/");
                        idValue = arr[arr.Length - 1];
                    }
                }
            }

            return await Task.FromResult(idValue);
        }

        public async Task<bool> CheckViewDetailRequest(Microsoft.AspNetCore.Http.HttpContext request)
        {
            var keyGroup = "/groups";
            var keyRole = "/roles";
            if (request != null)
            {
                if (request.Request.Method.Equals("GET") && !string.IsNullOrEmpty(request.Request.Path.Value))
                {
                    if (request.Request.Path.Value.Contains(keyGroup) || request.Request.Path.Value.Contains(keyRole))
                        return await Task.FromResult(true);
                }
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> CheckUserPermission(Microsoft.AspNetCore.Http.HttpContext request, string userName, string apiName)
        {
            //overwrite apiName again for view detail id
            if (await CheckViewDetailRequest(request))
            {
                var groupID = await GetIDFromViewDetailRequest(request, "/groups/");
                if (!string.IsNullOrEmpty(groupID))
                {
                    int.TryParse(groupID, out int ID);
                    if (ID > 0)
                        apiName = "/groups";
                }

                var roleID = await GetIDFromViewDetailRequest(request, "/roles/");
                if (!string.IsNullOrEmpty(roleID))
                {
                    int.TryParse(roleID, out int ID);
                    if (ID > 0)
                        apiName = "/roles";
                }
            }

            var whereCondition = string.Concat("WHERE u.UserName = '", userName, "' AND P.Status = '", nameof(PermissionStatus.Active), "' AND p.ApiUrl LIKE '%", apiName, "%' ");
            var orderbyCondition = " ORDER BY rg.RoleId ASC, rg.GroupId ASC";
            var query = string.Concat("SELECT distinctrow p.*, rg.RoleId, rg.GroupId "
                                    , "FROM users u "
                                    , "LEFT JOIN user_group ug ON u.Id = ug.UserId "
                                    , "LEFT JOIN ", _unitOfWork.DatabaseName, ".groups g ON ug.GroupId = g.GroupId "
                                    , "LEFT JOIN role_group rg ON rg.GroupId = g.GroupId "
                                    , "LEFT JOIN role_permission rp ON rp.RoleId = rg.RoleId "
                                    , "LEFT JOIN permissions p ON p.Id = rp.PermissionId "
                                    , whereCondition
                                    , orderbyCondition);

            var result = _unitOfWork.PermissionRepository.SqlQuery(query).ToList();
            if (result.Count > 0)
            {
                _logger.LogInformation($"{userName} - has permission with URL - {apiName}");
                return await Task.FromResult(true);
            }
            _logger.LogWarning($"{userName} - has NO permission with URL - {apiName}");
            return await Task.FromResult(false);
        }
        private void AssignValueToReturnObj(ReturnObjectDto result, string code, string message, string status, object data)
        {
            _logger.LogInformation(message);
            result.Code = code;
            result.Message = message;
            result.Status = status;
            result.Data = data;
        }
    }
}
