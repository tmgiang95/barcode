using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;

namespace Clean.WinF.Applications.Features.Computer.DTOs
{
    public class ComputerDto: BaseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MachineNumber { get; set; }
    }
}
