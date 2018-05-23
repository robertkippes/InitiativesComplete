using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class EngagementType
    {
        public EngagementType()
        {
            Initiative = new HashSet<Initiative>();
        }

        public int EngagementTypeId { get; set; }
        public bool IsActive { get; set; }
        public string EngagementTypeShortDescription { get; set; }
        public string EngagementTypeDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<Initiative> Initiative { get; set; }
    }
}
