using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Thread.DTOs;

namespace Clean.WinF.Applications.Features.Thread.Interfaces
{
    public interface IThreadCommandServices
    {
        Task<List<ThreadDto>> CreateNewThread(ThreadDto addedThread);
        Task<ThreadDto> UpdateThread(ThreadDto updatedThread);
        Task<List<ThreadDto>> DeleteThread(ThreadDto deletedThread);
    }
}
