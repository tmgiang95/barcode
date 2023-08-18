using Clean.WinF.Shared.DTOs;
using Clean.WinF.Shared.DTOs.Users;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IUserService
    {
        Task<ReturnObjectDto> GetUserByNTID(string ntid);
    }
}
