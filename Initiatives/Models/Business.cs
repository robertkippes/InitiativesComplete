using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Business : LastModified
    {
        public Business()
        {
            InitiativeBusiness = new HashSet<InitiativeBusiness>();
        }
        [Key]
        public int BusinessId { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string BusinessShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(25, MinimumLength = 3)]
        
        public string BusinessDescription { get; set; }
       

        public ICollection<InitiativeBusiness> InitiativeBusiness { get; set; }
    }
}
