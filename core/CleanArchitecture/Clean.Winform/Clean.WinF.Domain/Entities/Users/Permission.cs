using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities.Users
{
    [Table("permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public bool IsInserted { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsExecuted { get; set; }
        public int UserGroupID { get; set; }
        public virtual UserGroup UserGroups { get; set; }
    }
}
