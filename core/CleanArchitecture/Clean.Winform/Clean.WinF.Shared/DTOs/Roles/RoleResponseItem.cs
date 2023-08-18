using Clean.WinF.Shared.DTOs.Permission;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Roles
{
    public class RoleResponseItem
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class RoleGetByIdResponseItem
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public IList<PermissionGroupResponse> PermissionCategories { get; set; }
        public string Message { get; set; }
        public string CustomError { get; set; }
        public string Status { get; set; }
    }
}
