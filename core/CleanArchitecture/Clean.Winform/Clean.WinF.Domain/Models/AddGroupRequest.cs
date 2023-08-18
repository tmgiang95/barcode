using Clean.WinF.Shared.DTOs.LDAP;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class AddGroupRequest
    {
        [Required]
        public string GroupName { get; set; }
        public string Description { get; set; }
    }

    public class AddUsersDistributionListGroupRequest
    {
        [Required]
        public int GroupId { get; set; }

        public IList<LdapDto> LDAPUsers { get; set; }//names get from ldap

        public IList<LdapDto> DistributionLists { get; set; }//distribution list get from ldap

    }

    public class AddRolesGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public IList<string> Roles { get; set; }
    }

    public class UpdateGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }

    public class DeletedGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
    }

    public class RemoveUserGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserType { get; set; }
    }

    public class RemoveRoleGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }

    public class AddDistributionListGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public IList<LdapDto> selectedDistributionLists { get; set; }
    }

    public class RemoveDistributionListGroupRequest
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int DistributionListID { get; set; }
    }
}
