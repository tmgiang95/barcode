using Clean.WinF.Shared.DTOs.Users;

namespace Clean.WinF.Shared.DTOs.Permission
{
    public class RolePermissionDto
    {
        public int RoleId { get; set; }
        public virtual RoleDto Role { get; set; }
        public int PermissionId { get; set; }
        public virtual PermissionDto Permission { get; set; }
    }
}
