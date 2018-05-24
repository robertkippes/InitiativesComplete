using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Location : LastModified
    {
        public Location()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int LocationId { get; set; }
       public string LocationShortDescription { get; set; }
        public string LocationDescription { get; set; }
       public ICollection<Initiative> Initiative { get; set; }
    }
}
