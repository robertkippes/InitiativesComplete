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
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string EngagementTypeShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string EngagementTypeDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
