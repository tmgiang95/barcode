
using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class UserAccessRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Reason { get; set; }
    }

    public class InternalUserRequest
    {
        [Required]
        public string Username { get; set; }
    }

    public class UpdateUserRequest
    {
        [Required]
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UpdatedBy { get; set; }
        public string Reason { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
