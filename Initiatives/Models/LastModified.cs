using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models
{
    public class LastModified
    {
        [Display(Name = "Modified User")]
        [Column(TypeName = "nchar(150)")]
        public string ModifiedUserName { get; set; }
        [Display(Name = "Modified Date")]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Active")]
        [Column(TypeName = "bit")]
     public bool IsActive { get; set; }
    }
}
