using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;
namespace Clean.WinF.Applications.Features.Report.DTOs
{
    public  class ReportDto: BaseDTO
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
