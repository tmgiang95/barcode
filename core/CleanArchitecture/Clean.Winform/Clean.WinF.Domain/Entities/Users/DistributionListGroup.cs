using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.WinF.Domain.Entities.Users
{
    [Table("distributionlist_groups")]
    public class DistributionListGroup
    {
        public int DistributionListId { get; set; }
        public virtual DistributionList DistributionLists { get; set; }
        public int GroupId { get; set; }
        public virtual Group Groups { get; set; }
    }
}
