using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.WinF.Applications.DTOs
{
    public class BaseDTO
    {
        public long ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CustomErrorCode { get; set; }
        public string MessageRet { get; set; }
        public bool IsActive { get; set; }
    }
}
