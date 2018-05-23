using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Facility
    {
        public Facility()
        {
            InitiativeFacility = new HashSet<InitiativeFacility>();
        }

        public int FacilityId { get; set; }
        public bool IsActive { get; set; }
        public string FacilityShortDescription { get; set; }
        public string FacilityDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<InitiativeFacility> InitiativeFacility { get; set; }
    }
}
