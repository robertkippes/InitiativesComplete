using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class MetaTag : LastModified
    {
        public MetaTag()
        {
            InitiativeMetaTag = new HashSet<InitiativeMetaTag>();
        }
        [Key]
        public int MetaTagId { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string MetaTagShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string MetaTagDescription { get; set; }
        public ICollection<InitiativeMetaTag> InitiativeMetaTag { get; set; }
    }
}
