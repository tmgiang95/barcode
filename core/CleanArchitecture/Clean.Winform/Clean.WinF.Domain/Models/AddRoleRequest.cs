using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class AddRoleRequest
    {
        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class UpdateRoleRequest
    {
        [Required]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public IList<string> PermissionIds { get; set; }
    }

    public class DeletedRoleRequest
    {
        [Required]
        public int RoleId { get; set; }
    }
}
