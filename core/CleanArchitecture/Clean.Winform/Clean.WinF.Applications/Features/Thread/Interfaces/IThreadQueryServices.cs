using Clean.WinF.Applications.Features.Thread.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Thread.Interfaces
{
    public interface IThreadQueryServices
    {
        Task<ThreadDto> GetThreadById(int id);
        Task<List<ThreadDto>> GetThreadByName(string name);
        Task<List<ThreadDto>> GetThreadByCode(string code);
        Task<List<ThreadDto>> GetThreadBySuppName(string suppName);
        Task<List<ThreadDto>> GetThreadBySuppCode(string suppCode);
        Task<List<ThreadDto>> GetThreadByBatchNumber(string batchNumber);
        Task<List<ThreadDto>> GetThreadBySABLabel(string sabLabel);
        Task<List<ThreadDto>> GetAllThreads();
        Task<IEnumerable<ThreadDto>> ListAllAsync();
    }
}
