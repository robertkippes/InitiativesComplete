using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Facility : LastModified
    {
        public Facility()
        {
            InitiativeFacility = new HashSet<InitiativeFacility>();
        }
        [Key]
        public int FacilityId { get; set; }
        public string FacilityShortDescription { get; set; }
        public string FacilityDescription { get; set; }

        public ICollection<InitiativeFacility> InitiativeFacility { get; set; }
    }
}
