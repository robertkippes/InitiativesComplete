using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EAInitiatives
{
    public class IndexModel : PageModel
    {
        private readonly Initiatives.Models.InitiativeContext _context;

        public IndexModel(Initiatives.Models.InitiativeContext context)
        {
            _context = context;
        }

        public IList<Initiative> Initiative { get;set; }

        public async Task OnGetAsync()
        {
            Initiative = await _context.Initiative
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.LocationNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation).ToListAsync();
        }
    }
}
