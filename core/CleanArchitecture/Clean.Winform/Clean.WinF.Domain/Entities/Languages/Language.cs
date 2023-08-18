using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities.Languages
{
    [Table("Language")]
    public class Language
    {
        [Key]
        public int ID { get; set; }
        public string Code { get; set; }
        public string Lang { get; set; }
    }
}
