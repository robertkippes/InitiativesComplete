using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class SolutionType
    {
        public SolutionType()
        {
            Initiative = new HashSet<Initiative>();
        }

        public int SolutionTypeId { get; set; }
        public bool IsActive { get; set; }
        public string SolutionTypeShortDescription { get; set; }
        public string SolutionTypeDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }
        public ICollection<Initiative> Initiative { get; set; }
    }
}
