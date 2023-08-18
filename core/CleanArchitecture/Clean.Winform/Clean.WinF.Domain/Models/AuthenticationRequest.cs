using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class AuthenticationRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
