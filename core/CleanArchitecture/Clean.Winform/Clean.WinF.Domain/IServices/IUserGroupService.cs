using Clean.WinF.Shared.DTOs.Users;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IUserGroupService
    {
        Task<UserGroupDto> DeleteteGroup(UserGroupDto removedGroup);
    }
}
