using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class MetaTag 
    {
        public MetaTag()
        {
            InitiativeMetaTag = new HashSet<InitiativeMetaTag>();
        }
        public int MetaTagId { get; set; }
        public bool IsActive { get; set; }
        public string MetaTagShortDescription { get; set; }
        public string MetaTagDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        public ICollection<InitiativeMetaTag> InitiativeMetaTag { get; set; }
    }
}
