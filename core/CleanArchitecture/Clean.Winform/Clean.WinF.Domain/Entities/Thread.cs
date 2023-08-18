using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities
{
    [Table("Thread")]
    public class Thread: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SuppCode { get; set; }
        public string SuppName { get; set; }
        public string BatchNr { get; set; }
        public int Locked { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string SABLabel { get; set; }
    }
}
