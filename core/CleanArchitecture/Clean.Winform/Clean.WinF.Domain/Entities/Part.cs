using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities
{
    [Table("Part")]
    public class Part: BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
