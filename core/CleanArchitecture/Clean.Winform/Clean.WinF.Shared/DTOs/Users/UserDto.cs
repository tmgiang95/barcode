using System;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastActive { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string DisplayName { get; set; }
        public string Type { get; set; }
        public string CustomError { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public List<string> Permissions { get; set; }
    }
}
