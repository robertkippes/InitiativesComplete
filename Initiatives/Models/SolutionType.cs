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
        
        public string SolutionTypeShortDescription { get; set; }
        public string SolutionTypeDescription { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
