using System;
using System.Collections.Generic;

namespace Initiatives.Models
{
    
    public partial class InitiativeBusiness // A many-to-many join table without payload is sometimes called a pure join table (PJT).
    {
        public int InitiativeId { get; set; }
        public int BusinessId { get; set; }

        public Initiative Initiative { get; set; }
        public Business Business { get; set; }
    }
}
