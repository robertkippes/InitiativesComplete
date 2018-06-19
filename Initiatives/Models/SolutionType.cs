using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class SolutionType : LastModified
    {
        public SolutionType()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int SolutionTypeId { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string SolutionTypeShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string SolutionTypeDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
