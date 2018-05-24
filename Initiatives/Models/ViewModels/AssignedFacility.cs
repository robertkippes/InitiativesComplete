using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class AssignedFacility
    {
        public int FacilityId { get; set; }
        public string FacilityDescription { get; set; }
        public bool Assigned { get; set; }
    }
}
