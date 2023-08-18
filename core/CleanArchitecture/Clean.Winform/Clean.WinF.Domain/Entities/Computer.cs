using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities
{
    [Table("Computer")]
    public class Computer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int MachineNumber { get; set; }
        public Setting Settings { get; set; }
    }
}
