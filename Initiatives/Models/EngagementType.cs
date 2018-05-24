using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class EngagementType : LastModified
    {
        public EngagementType()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int EngagementTypeId { get; set; }
  public string EngagementTypeShortDescription { get; set; }
        public string EngagementTypeDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
