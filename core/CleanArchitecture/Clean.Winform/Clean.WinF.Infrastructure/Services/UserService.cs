//using Clean.WinF.Domain.Repository;
//using Clean.WinF.Domain.IServices;
//using Clean.WinF.Shared.DTOs;
//using Clean.WinF.Shared.Enums;
using System.Threading.Tasks;
using Clean.WinF.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Clean.WinF.Shared.Constants;
using Clean.WinF.Shared.ErrorMessage;

namespace Clean.WinF.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _userRepository;

        public UserService(IAsyncRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ReturnObjectDto> GetUserByNTID(string ntid)
        {
            var result = new ReturnObjectDto
            {
                Code = string.Empty,
                Message = string.Empty,
                Status = nameof(MessageReturnType.Success)
            };

            var user = await _userRepository
                .Query()
                .Include(u => u.UserGroups)
                .ThenInclude(ug => ug.Groups.RoleGroups)
                .ThenInclude(rg => rg.Roles.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(x => x.UserName == ntid);

            if (user == null)
            {
                result.SetError(CustomErrorCode.BP_USER_NOT_FOUND, string.Format(CustomErrorMessage.BP_USER_NOT_FOUND, ntid));
                return result;
            }

            result.Data = new
            {
                user.UserName,
                user.Status,
                UserId = user.Id,
                Groups = user.UserGroups.Select(ug => new
                {
                    ug.Groups.GroupId,
                    GroupName = ug.Groups.Name,
                    DisplayName = ug.Groups.Name,
                    ug.Groups.Description,
                    ug.Groups.Status,
                    Roles = ug.Groups.RoleGroups.Select(rg => new
                    {
                        RoleId = rg.Roles.Id,
                        RoleName = rg.Roles.Name,
                        DisplayName = rg.Roles.Name,
                        rg.Roles.Description,
                        rg.Roles.Status,
                        Permissions = rg.Roles.RolePermissions.Select(rp => new
                        {
                            PermissionId = rp.Permission.Id,
                            PermissionCode = rp.Permission.Code,
                            PermissionName = rp.Permission.Name,
                            DisplayName = rp.Permission.Name,
                            rp.Permission.Description,
                            rp.Permission.Status,
                            rp.BelongToRole
                        }).ToList()
                    }).ToList()
                }).ToList(),
            };

            return result;
        }
    }
}
