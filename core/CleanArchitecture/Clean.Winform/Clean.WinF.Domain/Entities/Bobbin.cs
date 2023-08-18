using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Clean.WinF.Domain.Entities
{
    [Table("Bobbin")]
    public class Bobbin: BaseEntity
    {
        public int BobbinNo { get; set; }
        public string BobbinLabel { get; set; }
        public string ThreadLabel { get; set; }
        public string StitchesOnBobbin { get; set; }
        public int MachineNumber { get; set; }
    }
}
