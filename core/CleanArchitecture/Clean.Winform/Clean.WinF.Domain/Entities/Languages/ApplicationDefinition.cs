using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities.Languages
{
    [Table("AppDefinition")]
    public class ApplicationDefinition
    {
        [Key]        
        public int AppID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
