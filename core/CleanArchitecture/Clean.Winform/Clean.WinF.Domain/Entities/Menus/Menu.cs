using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities.Menus
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public int ParentID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }
        public string Desciption { get; set; }
        public bool IsActive { get; set; }

    }
}
