using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Resource
    {
        public Resource()
        {
            Initiative = new HashSet<Initiative>();
        }

        public int ResourceId { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
