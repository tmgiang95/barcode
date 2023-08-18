using Clean.WinF.Shared.Enums;
using System.Collections.Generic;

namespace Clean.WinF.Domain.Models
{
    public class AuthenticationReponse
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public AuthenticateChallenge Challenge { get; set; }
        public UserSession UserSession { get; set; }
        public List<string> Permissions { get; set; }
    }
}
