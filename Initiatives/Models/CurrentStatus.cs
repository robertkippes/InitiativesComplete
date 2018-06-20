using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class CurrentStatus : LastModified
    {
        public CurrentStatus()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int CurrentStatusId { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string CurrentStatusShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string CurrentStatusDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
