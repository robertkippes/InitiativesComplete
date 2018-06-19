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
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string LocationShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string LocationDescription { get; set; }
       public ICollection<Initiative> Initiative { get; set; }
    }
}
