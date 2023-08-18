using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.WinF.Applications.DTOs;

namespace Clean.WinF.Applications.Features.Order.DTOs
{
    public class OrderDto: BaseDTO
    {
        public string OrderNo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public int OrderQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public string SABLabel { get; set; }
    }
}
