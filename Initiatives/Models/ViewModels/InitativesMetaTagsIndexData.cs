using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class InitativesMetaTagsIndexData
    {
        public IEnumerable<Initiative> Initiatives { get; set; }
        public IEnumerable<InitiativeMetaTag> InitiativeMetaTagCollection { get; set; }
        public IEnumerable<MetaTag> MetaTags { get; set; }
    }
}
