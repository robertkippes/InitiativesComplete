using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Models.ViewModels
{
    public class AssignedBusiness
    {
        public int BusinessId { get; set; }
        public string BusinessDescription { get; set; }
        public bool Assigned { get; set; }
    }
}
