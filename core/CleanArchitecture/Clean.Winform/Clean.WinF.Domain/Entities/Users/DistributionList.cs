using System;
using System.Collections.Generic;

namespace Clean.WinF.Domain.Entities.Users
{
    public class DistributionList
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Phonenumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<DistributionListGroup> DistributionListGroups { get; set; }
        public string Status { get; set; }
    }
}
