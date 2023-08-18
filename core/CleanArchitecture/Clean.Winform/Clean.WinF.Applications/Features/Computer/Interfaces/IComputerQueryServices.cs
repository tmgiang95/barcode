using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Computer.DTOs;
namespace Clean.WinF.Applications.Features.Computer.Interfaces
{
    public interface IComputerQueryServices
    {
        Task<ComputerDto> GetComputerById(int id);
        Task<ComputerDto> GetComputerNumber(string computerNo);
        Task<List<ComputerDto>> GetComputerByName(string computerName);
        Task<List<ComputerDto>> GetAllComputers();
        Task<IEnumerable<ComputerDto>> ListAllAsync();
    }
}
