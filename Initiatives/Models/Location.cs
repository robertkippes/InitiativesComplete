using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Location
    {
        public Location()
        {
            Initiative = new HashSet<Initiative>();
        }

        public int LocationId { get; set; }
        public string LocationShortDescription { get; set; }
        public string LocationDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<Initiative> Initiative { get; set; }
    }
}
