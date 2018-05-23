using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class InitativesIndexData
    {
        public IEnumerable<Initiative> Initiative { get; set; }
        public IEnumerable<InitiativeMetaTag> InitiativeMetaTagCollection { get; set; }
        public IEnumerable<MetaTag> MetaTag { get; set; }
    }
}
//public Initiative Initiative { get; set; }
//public MetaTag MetaTag { get; set; }