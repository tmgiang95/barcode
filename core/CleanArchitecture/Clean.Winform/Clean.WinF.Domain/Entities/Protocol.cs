using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities
{
    [Table("Protocol")]
    public class Protocol: BaseEntity
    {
        [Required]
        public string Label { get; set; }
        [Required]
        public string EndLabel { get; set; }
        [Required]
        public string SerialNo { get; set; }
        public bool SeamOK { get; set; }
        public bool SeamDetailStatus { get; set; }
        public string EndLabelSeamed1 { get; set; }
        public string EndLabe2Seamed { get; set; }
        public string StitchesCrit1 { get; set; }
        public string StitchesNotCrit1 { get; set; }
        public string StitchesCrit2 { get; set; }
        public string StitchesNotCrit2 { get; set; }
        public string StitchesCrit3 { get; set; }
        public string StitchesNotCrit4 { get; set; }

    }
}
