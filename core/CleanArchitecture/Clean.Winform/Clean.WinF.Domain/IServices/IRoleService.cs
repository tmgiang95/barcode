using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Shared.DTOs.Users;
using Clean.WinF.Shared.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IRoleService
    {
        Task<RoleDto> CreateNewRole(RoleDto addRole);
        Task<Shared.DTOs.Roles.RoleGetByIdResponseItem> GetRoleById(int RoleId);
        Task<IEnumerable<RoleDto>> ListAllRolesAsync();
        Task<PagedList<Role>> GetRoleByConditionAsync(PagingFilteringModel commandQuery);
        Task<RoleDto> UpdateRole(RoleDto updatedRole);
        Task<RoleDto> DeleteRole(RoleDto deletedRole);
    }
}
