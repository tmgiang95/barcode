using Clean.WinF.Applications.Features.Bobbin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Bobbin.Interfaces
{
    public interface IBobbinQueryServices
    {
        Task<BobbinDto> GetBobbinById(int id);
        Task<List<BobbinDto>> GetBobbinByLable(string bobLabel);
        Task<List<BobbinDto>> GetBobbinByThreadLable(string threadLabel);
        Task<List<BobbinDto>> GetBobbinByMachineNo(string machineNo);
        Task<List<BobbinDto>> GetAlls();
        Task<IEnumerable<BobbinDto>> ListAllAsync();
    }
}
