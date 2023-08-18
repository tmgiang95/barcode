using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities.Languages
{
    [Table("AppCodeGUIDefinition")]
    public class AppCodeGUIDefinition
    {
        [Key]
        public long ID { get; set; }
        public int AppID { get; set; }
        public string CodeGroupGUI { get; set; }
        public string CodeGUI { get; set; }
        public string ObjectType { get; set; }
        public string Languages { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
