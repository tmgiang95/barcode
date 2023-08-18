using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Bobbin.DTOs;

namespace Clean.WinF.Applications.Features.Bobbin.Interfaces
{
    public interface IBobbinCommandServices
    {
        Task<BobbinDto> CreateNewBobbin(BobbinDto addedBobbin);
        Task<BobbinDto> UpdateBobbin(BobbinDto updatedBobbin);
        Task<BobbinDto> DeleteBobbin(BobbinDto deletedBobbin);
    }
}
