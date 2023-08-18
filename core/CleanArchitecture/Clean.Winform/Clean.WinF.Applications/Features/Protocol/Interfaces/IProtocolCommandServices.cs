using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Protocol.DTOs;

namespace Clean.WinF.Applications.Features.Protocol.Interfaces
{
    public interface IProtocolCommandServices
    {
        Task<ProtocolDto> CreateNewProtocol(ProtocolDto addedProtocol);
        Task<ProtocolDto> UpdateProtocol(ProtocolDto updatedProtocol);
        Task<ProtocolDto> DeleteProtocol(ProtocolDto deletedProtocol);
    }
}
