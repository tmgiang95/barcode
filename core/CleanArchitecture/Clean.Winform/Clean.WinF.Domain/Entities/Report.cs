using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities
{
    [Table("Report")]
    public class Report: BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
