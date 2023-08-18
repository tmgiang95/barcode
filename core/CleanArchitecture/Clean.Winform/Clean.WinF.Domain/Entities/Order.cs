using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public string OrderNo { get; set; }
        public string ArticleCode { get; set; }
        public string ArticleName { get; set; }
        public int OrderQuantity { get; set; }
        public int ActualQuantity { get; set; }
        public string SABLabel { get; set; }
    }
}
