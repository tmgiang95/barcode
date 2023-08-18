
namespace Clean.WinF.Shared.DTOs.Email
{
    public class EmailDto
    {
        public string Host { get; set; }
        public string Sender { get; set; }
        public string UserNTID { get; set; }
        public string EmailTitle { get; set; }
        public string Reason { get; set; }
        public string Subject { get; set; }
        public string EmailReceiver { get; set; }
        public string EmailFileTemplate { get; set; }
    }
}
