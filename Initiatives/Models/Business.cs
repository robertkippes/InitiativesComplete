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
       
        public string BusinessShortDescription { get; set; }
        public string BusinessDescription { get; set; }
       

        public ICollection<InitiativeBusiness> InitiativeBusiness { get; set; }
    }
}
