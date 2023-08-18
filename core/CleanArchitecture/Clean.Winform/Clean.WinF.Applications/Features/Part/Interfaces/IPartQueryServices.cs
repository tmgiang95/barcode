using Clean.WinF.Applications.Features.Part.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Part.Interfaces
{
    public interface IPartQueryServices
    {
        Task<PartDto> GetPartById(int id);
        Task<List<PartDto>> GetPartByName(string name);
        Task<List<PartDto>> GetPartByCode(string code);
        Task<List<PartDto>> GetAllParts();
        Task<IEnumerable<PartDto>> ListAllAsync();
    }
}
