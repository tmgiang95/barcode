using System;
using System.ComponentModel.DataAnnotations;
namespace Clean.WinF.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
