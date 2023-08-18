using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities.Languages
{
    [Table("AppGroupGUIDefinition")]
    public class AppGroupGUIDefinition
    {
        [Key]
        public int ID { get; set; }
        public int AppID { get; set; }
        public string CodeGroup { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
