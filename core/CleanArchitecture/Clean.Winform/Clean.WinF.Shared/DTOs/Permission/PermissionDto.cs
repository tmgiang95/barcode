using Clean.WinF.Shared.DTOs.Users;
using System;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Permission
{
    public class PermissionDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsView { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCreated { get; set; }
        public bool IsModified { get; set; }
        public virtual ICollection<Users.PermissionDto> Permissions { get; set; }
        public virtual ICollection<RolePermissionDto> RolePermissionGroups { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string CustomError { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
