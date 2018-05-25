using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class AssignedMetaTag
    {
        public int MetaTagId { get; set; }
        public string MetaTagDescription { get; set; }
        public bool Assigned { get; set; }
    }
}
