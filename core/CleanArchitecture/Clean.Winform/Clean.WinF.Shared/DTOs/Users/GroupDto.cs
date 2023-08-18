using System;
using System.Collections.Generic;


namespace Clean.WinF.Shared.DTOs.Users
{
    public class GroupDto
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<ShortUserDto> Users { get; set; }
        public IList<ShortDistributionListDto> DistributionLists { get; set; }
        public IList<ShortRoleDto> Roles { get; set; }
        public string Message { get; set; }
        public string CustomError { get; set; }
    }

    public class ShortDistributionListDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public bool IsDistributionList { get; set; } = true;
        public IList<DistributionListDto> childGroups { get; set; }
    }

    public class ShortUserDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }

    public class ShortRoleDto
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
