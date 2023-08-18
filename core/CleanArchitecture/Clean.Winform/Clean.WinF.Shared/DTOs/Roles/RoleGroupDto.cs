using Clean.WinF.Shared.DTOs.Users;

namespace Clean.WinF.Shared.DTOs.Roles
{
    public class RoleGroupDto
    {
        public int RoleId { get; set; }
        public virtual RoleDto Roles { get; set; }
        public int GroupId { get; set; }
        public virtual GroupDto Groups { get; set; }
    }
}
