using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    /// <summary>
    /// Busines represents the COE's iat CHRISTUS Health
    /// </summary>
    public partial class Business : LastModified
    {
        public Business()
        {
            InitiativeBusiness = new HashSet<InitiativeBusiness>();
        }
        [Key]
        public int BusinessId { get; set; }
        [Display(Name = "Short Description", Description = "THis is the tool tip .... ",ShortName ="short Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string BusinessShortDescription { get; set; }
        [Display(Name = "Description")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        
        public string BusinessDescription { get; set; }
       

        public ICollection<InitiativeBusiness> InitiativeBusiness { get; set; }
    }
}
