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
        public string MetaTagShortDescription { get; set; }
        public string MetaTagDescription { get; set; }
        public ICollection<InitiativeMetaTag> InitiativeMetaTag { get; set; }
    }
}
