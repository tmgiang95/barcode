using AutoMapper;
using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IServices;
using Clean.WinF.Domain.Repository;
using Clean.WinF.Infrastructure.Utilities;
using Clean.WinF.Shared.Constants;
using Clean.WinF.Shared.DTOs.Email;
using Clean.WinF.Shared.DTOs.LDAP;
using Clean.WinF.Shared.DTOs.Users;
using Clean.WinF.Shared.Enums;
using Clean.WinF.Shared.ErrorMessage;
using Clean.WinF.Shared.Paging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        //private readonly IConfiguration _config;
        //private readonly IAsyncRepository<User> _userRepository;
        //private readonly IAsyncRepository<Permission> _permissionRepository;
        //private readonly IAsyncRepository<DistributionList> _distributionListRepository;
        //private readonly UserManager<User> _userManager;
        //private readonly ILogger<AccountService> _logger;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly ILdapService _ldap;
        //private readonly IMapper _mapper;

        //public AccountService(IAsyncRepository<User> userRepository,
        //                    IAsyncRepository<DistributionList> distributionListRepository,
        //                    UserManager<User> userMgmt,
        //                    ILogger<AccountService> logger,
        //                    IConfiguration config, IUnitOfWork unitOfWork,
        //                    ILdapService ldap, IMapper mapper, IAsyncRepository<Permission> permissionRepository)

        //{
        //    _config = config;
        //    _userRepository = userRepository;
        //    _distributionListRepository = distributionListRepository;
        //    _userManager = userMgmt;
        //    _logger = logger;
        //    _unitOfWork = unitOfWork;
        //    _ldap = ldap;
        //    _mapper = mapper;
        //    _permissionRepository = permissionRepository;
        //}
        //#region Public Methods
        //public async Task<UserDto> GetUserById(int id)
        //{
        //    var result = new UserDto();
        //    var userEntity = await _userRepository.Query().Include(b => b.UserGroups).FirstOrDefaultAsync(x => x.Id == id);

        //    if (userEntity != null)
        //    {
        //        if (!string.IsNullOrEmpty(userEntity.Status) && userEntity.Status.Equals(nameof(UserStatus.Active)))
        //        {
        //            return result = new UserDto
        //            {
        //                Id = userEntity.Id,
        //                UserName = userEntity.UserName,
        //                FullName = userEntity.FullName,
        //                Department = userEntity.Department,
        //                Email = userEntity.Email,
        //                PhoneNumber = userEntity.PhoneNumber,
        //                CreatedBy = userEntity.CreatedBy,
        //                UpdatedBy = userEntity.UpdatedBy,
        //                LastActive = userEntity.LastActive,
        //                Status = userEntity.Status
        //            };
        //        }
        //    }
        //    return result;
        //}

        //public async Task<UserDto> GetUserByUsername(string username)
        //{
        //    string formatedUsername = username.ToLower().Trim();

        //    return await _userRepository.Query()
        //        .Select(u => new UserDto
        //        {
        //            Id = u.Id,
        //            UserName = u.UserName,
        //            FullName = u.FullName,
        //            Department = u.Department,
        //            Email = u.Email,
        //            PhoneNumber = u.PhoneNumber,
        //            CreatedBy = u.CreatedBy,
        //            UpdatedBy = u.UpdatedBy,
        //            LastActive = u.LastActive,
        //            Status = u.Status
        //        })
        //        .FirstOrDefaultAsync(x => x.UserName == formatedUsername);
        //}

        //public async Task<PagedList<User>> GetUserAsync(PagingFilteringModel commandQuery)
        //{
        //    _logger.LogInformation($"Begining query all users records =  {commandQuery}");

        //    var mainQuery = _userRepository.Query().Include(b => b.UserGroups).AsQueryable();

        //    try
        //    {
        //        if (!string.IsNullOrEmpty(commandQuery.QueryParams))
        //        {
        //            var queryFilter = commandQuery.QueryParams.Trim().ToUpper();
        //            mainQuery = mainQuery.Where(
        //                x => x.UserName.Trim().ToUpper().Contains(queryFilter)
        //                || x.FullName.Trim().ToUpper().Contains(queryFilter)
        //                || x.Department.Trim().ToUpper().Contains(queryFilter)
        //                || x.Email.Trim().ToUpper().Contains(queryFilter));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogInformation($"Get all book: An error occured: {ex.ToString()}");
        //    }
        //    return await PagedList<User>.CreateAsync(mainQuery, commandQuery.PageNumber, commandQuery.PageSize);
        //}

        //public async Task<IEnumerable<UserDto>> ListAllAsync()
        //{
        //    IList<UserDto> userList = new List<UserDto>();

        //    var users = await _userRepository.ListAllAsync();
        //    if (users is null) return null;

        //    foreach (var userInfo in users)
        //    {
        //        if (!string.IsNullOrEmpty(userInfo.Status) && !userInfo.Status.Equals(nameof(UserStatus.Removed)))
        //        {
        //            userList.Add(new UserDto
        //            {
        //                Id = userInfo.Id,
        //                UserName = userInfo.UserName,
        //                FullName = userInfo.FullName,
        //                Department = userInfo.Department,
        //                CreatedBy = userInfo.CreatedBy,
        //                CreatedDate = userInfo.CreatedDate,
        //                Status = userInfo.Status
        //            });
        //        }
        //    }

        //    return userList;
        //}

        //public IEnumerable<UserDto> GetAllUsers()
        //{
        //    IList<UserDto> userDtos = new List<UserDto>();
        //    var _users = _userRepository.GetAll();

        //    if (_users != null && _users.Count() > 0)
        //    {
        //        foreach (var userInfo in _users)
        //        {
        //            var userDTo = new UserDto()
        //            {
        //                CreatedBy = userInfo.CreatedBy,
        //                Email = userInfo.Email,
        //                FullName = userInfo.FullName,
        //                Department = userInfo.Department,
        //                UserName = userInfo.UserName,
        //                Id = userInfo.Id,
        //                Status = userInfo.Status,
        //                Reason = userInfo.Reason
        //            };
        //            userDtos.Add(userDTo);
        //        }
        //    }
        //    return userDtos;
        //}

        //public async Task<UserDto> CreateInternalUser(UserDto internalUser, UserRequest requestAction)
        //{
        //    string userStatus = string.Empty;

        //    switch (requestAction)
        //    {
        //        case UserRequest.RequestAccess:
        //            userStatus = nameof(UserStatus.InActive);
        //            break;
        //        case UserRequest.CreateNew:
        //            userStatus = nameof(UserStatus.Active);
        //            break;
        //    }

        //    var newUser = new User()
        //    {
        //        UserName = internalUser.UserName.ToLower().Trim(),
        //        CreatedDate = DateTime.UtcNow,
        //        LastActive = DateTime.UtcNow,
        //        Email = !string.IsNullOrEmpty(internalUser.Email) ? internalUser.Email.Trim() : string.Empty,
        //        FullName = !string.IsNullOrEmpty(internalUser.FullName) ? internalUser.FullName.Trim() : string.Empty,
        //        Department = !string.IsNullOrEmpty(internalUser.Department) ? internalUser.Department.Trim() : string.Empty,
        //        PhoneNumber = !string.IsNullOrEmpty(internalUser.PhoneNumber) ? internalUser.PhoneNumber.Trim() : string.Empty,
        //        CreatedBy = !string.IsNullOrEmpty(BluePrintUtility.userNTIT) ? BluePrintUtility.userNTIT : BluePrintUtility.GetUserNTIDFromToken(_config),
        //        DisplayName = !string.IsNullOrEmpty(internalUser.DisplayName) ? internalUser.DisplayName.Trim() : string.Empty,
        //        Status = userStatus.Trim()
        //    };

        //    if (string.IsNullOrEmpty(newUser.NormalizedUserName))
        //        newUser.NormalizedUserName = internalUser.UserName.ToUpper();

        //    if (string.IsNullOrEmpty(newUser.NormalizedEmail))
        //        newUser.NormalizedEmail = internalUser.Email.ToUpper();

        //    if (string.IsNullOrEmpty(newUser.SecurityStamp))
        //        newUser.SecurityStamp = Guid.NewGuid().ToString().ToUpper().Replace("-", string.Empty);

        //    try
        //    {
        //        var createdUser = _unitOfWork.UserRepository.AddAsync(newUser).Result;
        //        _unitOfWork.Complete();
        //        createdUser = _unitOfWork.UserRepository.Query().FirstOrDefault(x => x.UserName == newUser.UserName);
        //        internalUser = _mapper.Map<UserDto>(createdUser);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"CreateInternalUser() error: {ex.ToString()}");
        //        internalUser.CustomError = CustomErrorCode.BP_INTERNAL_USER_CREATE_FAIL;
        //        internalUser.Message = string.Format(CustomErrorMessage.BP_INTERNAL_USER_CREATE_FAIL, newUser.UserName);
        //        return internalUser;
        //    }

        //    internalUser.Status = userStatus;

        //    return internalUser;
        //}

        //public async Task<UserDto> RequestAccessInternalUser(string ntId, string reason)
        //{
        //    var result = new UserDto();
        //    string errMsg = string.Empty;

        //    // Check existed user in database or not
        //    var existedUser = await CheckExistedUserInDB(ntId, UserRequest.RequestAccess);
        //    if (existedUser != null && !string.IsNullOrEmpty(existedUser.CustomError))
        //    {
        //        result.Message = existedUser.Message;
        //        result.CustomError = existedUser.CustomError;
        //        return result;
        //    }

        //    // Check user exist from LDAP 
        //    var userLDAP = CheckExistedUserInLDAP(ntId.Trim());
        //    if (userLDAP != null && !string.IsNullOrEmpty(userLDAP.CustomError))
        //        return userLDAP;

        //    //Send email for admin
        //    var emailRequest = new EmailDto()
        //    {
        //        Host = _config["EmailSetting:EmailSmtpHost"],
        //        Sender = _config["EmailSetting:EmailSender"],
        //        UserNTID = ntId,
        //        Subject = string.Concat("[BlueprintDotNet] - Request access to register user: ", ntId),
        //        EmailReceiver = userLDAP.Email,
        //        EmailFileTemplate = Environment.CurrentDirectory + "/SendEmail/request-access-template.html",
        //        Reason = reason
        //    };

        //    bool resultSendEmail = BluePrintUtility.SendEmailInBosch(_logger, emailRequest, Boolean.Parse(_config["EmailSetting:AutoSending"]));
        //    if (!resultSendEmail)
        //    {
        //        errMsg = string.Concat("Send email to request access user: ", ntId, " is failed!");
        //        result.Message = errMsg;
        //        result.CustomError = CustomErrorCode.BP_USER_SEND_EMAIL_REQUEST_FAIL;
        //        _logger.LogInformation(errMsg);
        //        return result;
        //    }

        //    result.UserName = ntId;
        //    result.Reason = reason;
        //    result.Email = userLDAP.Email;
        //    result.FullName = userLDAP.FullName;
        //    result.Department = userLDAP.Department;
        //    result.DisplayName = userLDAP.DisplayName;

        //    //inserted temporary user info into user table
        //    //this behavior will avoid user spam send many request access times to admin email
        //    var internalUser = CreateInternalUser(result, UserRequest.RequestAccess);
        //    if (internalUser != null && !string.IsNullOrEmpty(internalUser.Result.Message))
        //    {
        //        errMsg = string.Concat("Unable to create new internal user ", ntId, " successfully");
        //        _logger.LogError(errMsg);
        //        result.Message = errMsg;
        //        result.CustomError = CustomErrorCode.BP_INTERNAL_USER_CREATE_FAIL;
        //        return result;
        //    }

        //    return result;
        //}

        //public UserDto GetUserInfo(int userID)
        //{
        //    {
        //        var result = new UserDto
        //        {
        //            Id = userID,
        //            Permissions = new List<string>()
        //        };

        //        var groups = _unitOfWork.UserGroupRepository.GetAll().Where(x => x.UserId == userID)?.ToList();
        //        if (groups != null && groups.Any())
        //        {
        //            foreach (var item in groups)
        //            {
        //                string sqlQuery = "SELECT DISTINCT a.*" +
        //                           " FROM permissions a" +
        //                           " INNER JOIN role_permission c ON a.Id = c.PermissionId" +
        //                           " INNER JOIN role_group d ON c.RoleId = d.RoleId" +
        //                           $" WHERE d.GroupId = {item.GroupId} and c.BelongToRole = 1";

        //                var permissions = _permissionRepository.SqlQuery(sqlQuery)?.ToList();

        //                _logger.LogInformation(sqlQuery);

        //                if (permissions != null && permissions.Count > 0)
        //                {
        //                    foreach (var permission in permissions)
        //                    {
        //                        var permissionDto = _mapper.Map<PermissionDto>(permission);
        //                        if (permissionDto.ParentId != 0 && !result.Permissions.Contains(permissionDto.Name))
        //                        {
        //                            result.Permissions.Add(permissionDto.Code);
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        return result;
        //    }
        //}

        //public IList<string> GetValidPermissions(int userId)
        //{
        //    var roleActiveStatus = nameof(RoleStatus.Active);
        //    var groupActiveStatus = nameof(GroupStatus.Active);
        //    return _permissionRepository.Query()
        //        .Where(p => p.ParentId != 0
        //                    && p.RolePermissions.Any(rp => rp.BelongToRole == true
        //                                                && rp.Role.Status == roleActiveStatus
        //                                                && rp.Role.RoleGroups.Any(rg => rg.Group.Status == groupActiveStatus
        //                                                                            && rg.Group.UserGroups.Any(gu => gu.UserId == userId))))
        //        .Select(p => p.Code)
        //        .Distinct()
        //        .ToList();
        //}

        //public async Task<UserDto> CreateNewUser(UserDto createdUser)
        //{
        //    var result = await SaveNewUserIntoDB(createdUser, UserType.Normal);
        //    return result;
        //}

        //public async Task<UserDto> DeleteUser(UserDto deletedUser)
        //{
        //    var result = new UserDto();

        //    var existedUser = await CheckExistedUserInDB(deletedUser.UserName, UserRequest.Delete);
        //    if (existedUser != null && !string.IsNullOrEmpty(existedUser.CustomError))
        //    {
        //        result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
        //        result.Message = string.Format(CustomErrorMessage.BP_USER_NOT_FOUND, deletedUser.UserName);
        //        return result;
        //    }

        //    existedUser.Status = nameof(UserStatus.Removed);
        //    try
        //    {
        //        var resultRemoved = await _unitOfWork.UserRepository.UpdateAsync(existedUser);
        //        _unitOfWork.Complete();
        //        result = UpdateUserDtoInfo(resultRemoved);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"DeleteUser() error: {ex.ToString()}");
        //        result.Message = string.Format(CustomErrorMessage.BP_INTERNAL_USER_REMOVED_FAIL, existedUser.UserName);
        //        result.CustomError = CustomErrorCode.BP_INTERNAL_USER_REMOVED_FAIL;
        //    }

        //    return result;
        //}

        //public async Task<UserDto> UpdateUser(UserDto updatedUser)
        //{
        //    var result = new UserDto();

        //    var existedUser = await CheckExistedUserInDB(updatedUser.UserName, UserRequest.Update);

        //    if (existedUser != null && !string.IsNullOrEmpty(existedUser.CustomError))
        //    {
        //        result.CustomError = existedUser.CustomError;
        //        result.Message = existedUser.Message;
        //        return result;
        //    }

        //    if (string.IsNullOrEmpty(updatedUser.UserName.Trim()))
        //    {
        //        result.CustomError = CustomErrorCode.BP_USER_NAME_EMPTY;
        //        result.Message = CustomErrorMessage.BP_USER_NAME_EMPTY;
        //        return result;
        //    }

        //    if (string.IsNullOrEmpty(updatedUser.FullName.Trim()))
        //    {
        //        result.CustomError = CustomErrorCode.BP_USER_FULL_NAME_EMPTY;
        //        result.Message = CustomErrorMessage.BP_USER_FULL_NAME_EMPTY;
        //        return result;
        //    }

        //    if (string.IsNullOrEmpty(updatedUser.Email.Trim()))
        //    {
        //        result.CustomError = CustomErrorCode.BP_USER_EMAIL_EMPTY;
        //        result.Message = CustomErrorMessage.BP_USER_EMAIL_EMPTY;
        //        return result;
        //    }

        //    if (BluePrintUtility.HasSpecialCharacters(updatedUser.UserName.Trim()))
        //    {
        //        result.CustomError = CustomErrorCode.BP_USER_INVALID_NAME;
        //        result.Message = CustomErrorMessage.BP_USER_INVALID_NAME;
        //        return result;
        //    }

        //    if (!string.IsNullOrEmpty(updatedUser.FullName))
        //        existedUser.FullName = updatedUser.FullName;

        //    if (!string.IsNullOrEmpty(updatedUser.Email))
        //        existedUser.Email = updatedUser.Email;

        //    if (!string.IsNullOrEmpty(updatedUser.Department))
        //        existedUser.Department = updatedUser.Department;

        //    if (!string.IsNullOrEmpty(updatedUser.PhoneNumber))
        //        existedUser.PhoneNumber = updatedUser.PhoneNumber;

        //    if (!string.IsNullOrEmpty(updatedUser.UpdatedBy))
        //        existedUser.UpdatedBy = updatedUser.UpdatedBy;

        //    existedUser.LastActive = DateTime.UtcNow;

        //    if (!string.IsNullOrEmpty(updatedUser.Reason))
        //        existedUser.Reason = updatedUser.Reason;

        //    if (!string.IsNullOrEmpty(updatedUser.Status))
        //    {
        //        if (!ValidateUserStatus(updatedUser.Status))
        //        {
        //            result.Message = CustomErrorMessage.BP_INVALID_USER_STATUS;
        //            result.CustomError = CustomErrorCode.BP_INVALID_USER_STATUS;
        //            return result;
        //        }
        //        existedUser.Status = updatedUser.Status;
        //    }

        //    try
        //    {
        //        var resultUpdated = await _unitOfWork.UserRepository.UpdateAsync(existedUser);
        //        _unitOfWork.Complete();
        //        result = UpdateUserDtoInfo(resultUpdated);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"UpdateUser() error: { ex.ToString()}");
        //        result.Message = string.Format(CustomErrorMessage.BP_INTERNAL_USER_UPDATED_FAIL, existedUser.UserName);
        //        result.CustomError = CustomErrorCode.BP_INTERNAL_USER_UPDATED_FAIL;
        //        return result;
        //    }

        //    return result;
        //}

        //public async Task<IList<LdapDto>> SearchUserFromLDAP(string searchUser)
        //{
        //    return _ldap.SearchUser(searchUser);
        //}

        //public async Task<IList<LdapDto>> SearchDistributionListFromLDAP(string strSearchDistributionList)
        //{
        //    return _ldap.SearchDistributionList(strSearchDistributionList);
        //}
        //#endregion

        //#region Private Methods
        //private bool ValidateUserStatus(string userStatus)
        //{
        //    if (string.IsNullOrEmpty(userStatus))
        //        return false;

        //    if (userStatus == nameof(UserStatus.Active)
        //        || userStatus == nameof(UserStatus.InActive)
        //        || userStatus == nameof(UserStatus.Removed))
        //        return true;

        //    return false;
        //}

        //private UserDto UpdateUserDtoInfo(User userEntity)
        //{
        //    if (userEntity is null) return null;

        //    var userDTO = new UserDto()
        //    {
        //        Id = userEntity.Id,
        //        FullName = userEntity.FullName,
        //        Department = userEntity.Department,
        //        Email = userEntity.Email,
        //        PhoneNumber = userEntity.PhoneNumber,
        //        Reason = userEntity.Reason,
        //        UpdatedBy = userEntity.UpdatedBy,
        //        Status = userEntity.Status
        //    };

        //    return userDTO;
        //}

        //private async Task<UserDto> SaveNewUserIntoDB(UserDto createdUser, UserType type)
        //{
        //    var result = new UserDto();
        //    string errMsg = string.Empty;

        //    //check existed db
        //    var existedUser = await CheckExistedUserInDB(createdUser.UserName, UserRequest.CreateNew);
        //    if (existedUser != null && !string.IsNullOrEmpty(existedUser.CustomError))
        //    {
        //        result.Message = existedUser.Message;
        //        result.CustomError = existedUser.CustomError;
        //        return result;
        //    }

        //    if (string.IsNullOrEmpty(createdUser.UserName.Trim()))
        //    {
        //        result.Message = CustomErrorCode.BP_USER_NAME_EMPTY;
        //        result.CustomError = CustomErrorMessage.BP_USER_NAME_EMPTY;
        //        return result;
        //    }

        //    //check existed LDAP
        //    if (type.Equals(UserType.Normal))
        //    {
        //        result = CheckExistedUserInLDAP(createdUser.UserName);
        //        if (result != null && !string.IsNullOrEmpty(result.CustomError))
        //            return result;
        //    }

        //    //add new to db
        //    var userDto = await CreateInternalUser(result, UserRequest.CreateNew);

        //    if (userDto != null && !string.IsNullOrEmpty(userDto.Message))
        //    {
        //        _logger.LogError(userDto.Message);
        //        result.Message = userDto.Message;
        //        result.CustomError = CustomErrorCode.BP_INTERNAL_USER_CREATE_FAIL;
        //        return result;
        //    }

        //    return userDto;
        //}

        //private UserDto CheckExistedUserInLDAP(string ntID)
        //{
        //    var result = new UserDto();

        //    // Check user exist from LDAP
        //    var userLDAP = _ldap.FindByUserId(ntID);
        //    if (userLDAP == null)
        //    {
        //        string errMsg = $"Username: {ntID} is not existed in LDAP!";
        //        result.Message = errMsg;
        //        result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
        //        _logger.LogInformation(errMsg);
        //        return result;
        //    }

        //    result.UserName = ntID.Trim();
        //    result.Email = userLDAP.Email.Trim();
        //    result.FullName = !string.IsNullOrEmpty(userLDAP.FullName) ? userLDAP.FullName.Trim() : BluePrintUtility.GetFullNameAndDepartmentFromLDAPUser(userLDAP.DisplayName, false);
        //    result.Department = !string.IsNullOrEmpty(userLDAP.Department) ? userLDAP.Department.Trim() : BluePrintUtility.GetFullNameAndDepartmentFromLDAPUser(userLDAP.DisplayName, true);
        //    result.PhoneNumber = !string.IsNullOrEmpty(userLDAP.PhoneNumber) ? userLDAP.PhoneNumber.Trim() : string.Empty;
        //    result.Country = !string.IsNullOrEmpty(userLDAP.Country) ? userLDAP.Country.Trim() : string.Empty;
        //    result.City = !string.IsNullOrEmpty(userLDAP.City) ? userLDAP.City.Trim() : string.Empty;
        //    result.DisplayName = !string.IsNullOrEmpty(userLDAP.DisplayName) ? userLDAP.DisplayName.Trim() : string.Empty;

        //    return result;
        //}

        //private async Task<User> CheckExistedUserInDB(string ntID, UserRequest reqAction)
        //{
        //    var result = new User();

        //    // Check existed user in database or not
        //    var existedUser = await _userManager.FindByNameAsync(ntID.Trim());
        //    if (existedUser != null)
        //    {
        //        if (reqAction == UserRequest.RequestAccess)
        //        {
        //            if (existedUser.Status.Equals(nameof(UserStatus.InActive)))
        //            {
        //                result.Message = $"Username: {ntID} is waiting to be approved by admin!"; ;
        //                result.CustomError = CustomErrorCode.BP_USER_WAITED_TO_APPROVAL;
        //                return result;
        //            }

        //            if (existedUser.Status.Equals(nameof(UserStatus.Removed)))
        //            {
        //                result.Message = $"Username: {ntID} is inactive and needs to contact to admin to re-activate!"; ;
        //                result.CustomError = CustomErrorCode.BP_USER_WAITED_TO_APPROVAL;
        //                return result;
        //            }

        //            if (existedUser.Status.Equals(nameof(UserStatus.Active)))
        //            {
        //                result.Message = $"Username: {ntID} is existed already!";
        //                result.CustomError = CustomErrorCode.BP_USER_EXISTED_ALREADY;
        //                return result;
        //            }
        //        }

        //        if (reqAction == UserRequest.CreateNew)
        //        {
        //            result.Message = $"Username: {ntID} is existed already!";
        //            result.CustomError = CustomErrorCode.BP_USER_EXISTED_ALREADY;
        //            return result;
        //        }
        //    }
        //    else
        //    {
        //        if (reqAction == UserRequest.Delete || reqAction == UserRequest.Update)
        //        {
        //            result.Message = string.Format(CustomErrorMessage.BP_USER_NOT_FOUND, ntID);
        //            result.CustomError = CustomErrorCode.BP_USER_NOT_FOUND;
        //            return result;
        //        }
        //    }

        //    return existedUser;
        //}
        //#endregion
    }
}
