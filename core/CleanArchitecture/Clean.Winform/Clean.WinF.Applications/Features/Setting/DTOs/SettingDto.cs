using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.Features.Setting.DTOs
{
    public class SettingDto
    {
        public int ID { get; set; }
        public string ComputerName { get; set; }
        public string LanguageBiasysControl { get; set; }
        public string LanguageBiasysDB { get; set; }
        public string Port { get; set; }
        public string PathOfBiasysControl { get; set; }
        public string PathOfProtocolDB { get; set; }
        public int IsActive { get; set; }
    }
}
