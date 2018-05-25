using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models
{
    public class LastModified
    {
        [Display(Name = "Last Modified User")]
        [Column(TypeName = "nchar(150)")]
        public string ModifiedUserName { get; set; }
        [Display(Name = "Last Modified Date")]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
    }
}
