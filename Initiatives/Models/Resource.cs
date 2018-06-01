using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Resource : LastModified
    {
        public Resource()
        {
            Initiative = new HashSet<Initiative>();
        }
        [Key]
        public int ResourceId { get; set; }
       
        [Display(Name = "First Name")]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(15, MinimumLength = 3)]
        public string LastName { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
