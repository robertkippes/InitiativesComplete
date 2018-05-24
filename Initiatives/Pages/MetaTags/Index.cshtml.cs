using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Initiatives.Models;

namespace Initiatives.Pages.MetaTags
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<MetaTag> MetaTag { get;set; }

        public async Task OnGetAsync()
        {
            MetaTag = await _context.MetaTag.ToListAsync();
        }
    }
}
