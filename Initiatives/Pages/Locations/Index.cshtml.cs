using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<Location> locationIq = from s in _context.Location
                                              select s;
            locationIq = locationIq.Where(s => s.IsActive).AsNoTracking();
            Location = await locationIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();
        }
    }
}
