using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class InitativesFacilitiesIndexData
    {
        public IEnumerable<Initiative> Initiatives { get; set; }
        public IEnumerable<InitiativeFacility> InitiativeFacilitiesCollection { get; set; }
        public IEnumerable<Facility> Facilities { get; set; }
    }
}
//public Initiative Initiative { get; set; }
//public MetaTag MetaTag { get; set; }