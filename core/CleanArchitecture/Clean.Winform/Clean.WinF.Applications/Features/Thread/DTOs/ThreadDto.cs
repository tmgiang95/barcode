using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;
namespace Clean.WinF.Applications.Features.Thread.DTOs
{
    public class ThreadDto: BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string BatchNr { get; set; }
        public string Locked { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string SABLabel { get; set; }
    }
}
