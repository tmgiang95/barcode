using Clean.WinF.Shared.DTOs.Users;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Permission
{
    public class PermissionGroupDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ApiUrl { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ICollection<PermissionDto> permissions { get; set; }
    }
}
