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
        [Required]
        [Column(TypeName = "nchar(150)")]
        public string ModifiedUserName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
       public bool IsActive { get; set; }
    }
}
