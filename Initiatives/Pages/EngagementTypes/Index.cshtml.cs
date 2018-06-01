using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EngagementTypes
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<EngagementType> EngagementType { get;set; }

        public async Task OnGetAsync()
        {
            //EngagementType = await _context.EngagementType.ToListAsync();
            IQueryable<EngagementType> engagementTypeIq = from s in _context.EngagementType
                                                          select s;
            engagementTypeIq = engagementTypeIq.Where(s => s.IsActive).AsNoTracking();
            EngagementType = await engagementTypeIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();
        }
    }
}
