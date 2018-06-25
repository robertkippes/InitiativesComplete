using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EAInvolvements
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<EAInvolvement> EAInvolvement { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EAInvolvement> locationIq = from s in _context.EAInvolvement
                                              select s;
            locationIq = locationIq.Where(s => s.IsActive).AsNoTracking();
            EAInvolvement = await locationIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();
        }
    }
}
