using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities.Users
{
    [Table("users")]
    public class User 
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string WinAccount { get; set; }
        public string ComputerNumber { get; set; }
        public bool ZKFingerReader { get; set; }
        public string FirstFinger { get; set; }
        public string SecondFinger { get; set; }
        public string ThirdFinger { get; set; }
        public DateTime ExpiredDate { get; set; }
        [Required]    
        public string UserID { get;set; }
        [Required]
        public string Password { get; set; }
        public string UserImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }  
        public int UserGroupID { get;set; }
        public virtual UserGroup UserGroups { get; set; }  
        public bool IsActive { get; set; }
    }
}
