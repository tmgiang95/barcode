using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.Features.Setting.DTOs;

namespace Clean.WinF.Applications.Features.Setting.Interfaces
{
    public interface IBobbinCommandServices
    {
        Task<List<SettingDto>> CreateNewSetting(SettingDto addedSetting);
        Task<SettingDto> UpdateSetting(SettingDto updatedSetting);
        Task<List<SettingDto>> DeleteSetting(SettingDto deletedSetting);
    }
}
