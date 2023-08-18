using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Shared.DTOs.Users;
using Clean.WinF.Shared.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IAccountService
    {
        Task<UserDto> GetUserById(int id);
        Task<UserDto> GetUserByUsername(string username);
        Task<PagedList<User>> GetUserAsync(PagingFilteringModel commandQuery);
        IEnumerable<UserDto> GetAllUsers();
        Task<IEnumerable<UserDto>> ListAllAsync();
        Task<UserDto> RequestAccessInternalUser(string ntId, string reason);
        Task<UserDto> CreateNewUser(UserDto addedUser);
        Task<UserDto> UpdateUser(UserDto deletedUser);
        Task<UserDto> DeleteUser(UserDto deletedUser);
        UserDto GetUserInfo(int id);
        IList<string> GetValidPermissions(int userId);
    }
}
