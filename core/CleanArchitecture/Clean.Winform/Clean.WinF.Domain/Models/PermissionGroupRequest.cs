using Clean.WinF.Shared.DTOs.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class PermissionGroupAddNewRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsView { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsCreated { get; set; }
        [Required]
        public bool IsModified { get; set; }

        [Required]
        public int RoleId { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }
    }

    public class PermissionGroupUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsView { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool IsCreated { get; set; }
        [Required]
        public bool IsModified { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string Status { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }
    }

    public class DeletedPermissionGroupRequest
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string PermissionGroupId { get; set; }
    }
}
