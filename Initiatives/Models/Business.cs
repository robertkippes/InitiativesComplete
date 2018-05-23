using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Initiatives.Models
{
    public partial class Business
    {
        public Business()
        {
            InitiativeBusiness = new HashSet<InitiativeBusiness>();
        }

        public int BusinessId { get; set; }
        public bool IsActive { get; set; }
        public string BusinessShortDescription { get; set; }
        public string BusinessDescription { get; set; }
        public string ModifiedUserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastModifiedDate { get; set; }

        public ICollection<InitiativeBusiness> InitiativeBusiness { get; set; }
    }
}
