using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class InitativesBusinessIndexData
    {
        public IEnumerable<Initiative> Initiatives { get; set; }
        public IEnumerable<InitiativeBusiness> InitiativeBusinessCollection { get; set; }
        public IEnumerable<Business> Businesses { get; set; }
    }
}
//public Initiative Initiative { get; set; }
//public MetaTag MetaTag { get; set; }