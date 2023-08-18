using Clean.WinF.Shared.DTOs.Permission;
using System;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Users
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ApiUrl { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<RolePermissionDto> RolePermissions { get; set; }
    }
}
