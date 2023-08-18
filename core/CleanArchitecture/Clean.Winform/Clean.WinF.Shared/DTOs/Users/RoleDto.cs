using Clean.WinF.Shared.DTOs.Permission;
using Clean.WinF.Shared.DTOs.Roles;
using System;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Users
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public IList<string> Permissions { get; set; }
        public IList<string> Groups { get; set; }
        public string Message { get; set; }
        public string CustomError { get; set; }
        public string Status { get; set; }

        public virtual ICollection<RoleGroupDto> RoleGroups { get; set; }
        public virtual ICollection<RolePermissionDto> RolePermissionGroups { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
