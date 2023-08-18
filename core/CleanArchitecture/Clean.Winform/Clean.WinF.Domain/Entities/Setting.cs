using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        public int ID { get; set; }
        public string ComputerName { get; set; }
        public string LanguageBiasysControl { get; set; }
        public string LanguageBiasysDB { get; set; }
        public string Port { get; set; }
        public string PathOfBiasysControl { get; set; }
        public string PathOfProtocolDB { get; set; }
        [Required]
        public int ComputerID { get; set; }
        public Computer Computers { get; set; }
        public bool IsActive { get; set; }
    }
}
