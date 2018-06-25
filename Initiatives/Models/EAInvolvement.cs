using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models
{
    public class EAInvolvement : LastModified
    {
        public EAInvolvement()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int EAInvolvementId { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string EAInvolvementShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string EAInvolvementDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
