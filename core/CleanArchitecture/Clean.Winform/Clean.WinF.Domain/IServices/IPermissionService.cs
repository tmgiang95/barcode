using Clean.WinF.Shared.DTOs;
using Clean.WinF.Shared.DTOs.Users;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IPermissionService
    {
        Task<ReturnObjectDto> GetAll();
        Task<ReturnObjectDto> GetByPermissionId(int permissionId);
        Task<ReturnObjectDto> GetByPermissionName(string permissionName);
        Task<ReturnObjectDto> AddNew(PermissionDto dto);
        Task<ReturnObjectDto> Update(PermissionDto dto);
        Task<ReturnObjectDto> Delete(PermissionDto dto);
        Task<bool> CheckUserPermission(Microsoft.AspNetCore.Http.HttpContext request, string userName, string apiName);
    }
}
