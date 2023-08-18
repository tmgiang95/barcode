using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;
namespace Clean.WinF.Applications.Features.Supplier.DTOs
{
    public class SupplierDto: BaseDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Remark { get; set; }
    }
}
