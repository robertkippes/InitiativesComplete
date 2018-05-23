using System;
using System.Collections.Generic;

namespace Initiatives.Models
{
    
    public partial class InitiativeMetaTag // A many-to-many join table without payload is sometimes called a pure join table (PJT).
    {
        public int InitiativeId { get; set; }
        public int MetaTagId { get; set; }

        public Initiative Initiative { get; set; }
        public MetaTag MetaTag { get; set; }
    }
}
