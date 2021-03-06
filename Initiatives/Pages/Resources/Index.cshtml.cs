using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Resources
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<Resource> Resource { get;set; }

        public async Task OnGetAsync()
        {
            //Resource = await _context.Resource.ToListAsync();
            IQueryable<Resource> resourceIq = from s in _context.Resource
                                                          select s;
            resourceIq = resourceIq.Where(s => s.IsActive).AsNoTracking();
            Resource = await resourceIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();

        }
    }
}
