using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Computer.DTOs;

namespace Clean.WinF.Applications.Features.Computer.Interfaces
{
    public interface IComputerCommandServices
    {
        Task<ComputerDto> CreateNewComputer(ComputerDto addedComputer);
        Task<ComputerDto> UpdateComputer(ComputerDto updatedComputer);
        Task<ComputerDto> DeleteComputer(ComputerDto deletedComputer);
    }
}
