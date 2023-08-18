using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;

namespace Clean.WinF.Applications.Features.Bobbin.DTOs
{
    public class BobbinDto: BaseDTO
    {
        public int BobbinNo { get; set; }
        public string BobbinLabel { get; set; }
        public string ThreadLabel { get; set; }
        public string StitchesOnBobbin { get; set; }
        public int MachineNumber { get; set; }
    }
}
