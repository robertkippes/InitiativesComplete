using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string FacilityShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string FacilityDescription { get; set; }

        public ICollection<InitiativeFacility> InitiativeFacility { get; set; }
    }
}
