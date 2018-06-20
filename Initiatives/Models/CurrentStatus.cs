using System;
using System.Collections.Generic;

namespace Initiatives.Models
{
    public partial class CurrentStatus
    {
        public int CurrentStatusId { get; set; }
        public string CurrentStatusDescription { get; set; }
        public string CurrentStatustShortDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string ModifiedUserName { get; set; }
    }
}
