using System.Collections.Generic;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Part.DTOs;

namespace Clean.WinF.Applications.Features.Part.Interfaces
{
    public interface IPartCommandServices
    {
        Task<PartDto> CreateNewPart(PartDto addedPart);
        Task<PartDto> UpdatePart(PartDto updatedPart);
        Task<PartDto> DeletePart(PartDto deletedPart);
    }
}
