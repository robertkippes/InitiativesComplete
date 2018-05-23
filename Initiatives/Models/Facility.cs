using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Facility
    {
        public Facility()
        {
            Initiative = new HashSet<Initiative>();
        }

        public int FacilityId { get; set; }
        public string FacilityShortDescription { get; set; }
        public string FacilityDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<Initiative> Initiative { get; set; }
    }
}
