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
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public bool IncludeDeleted { get; set; }
        public int InitativeId { get; set; }
        public IList<Initiative> Initiative { get;set; }

        public async Task OnGetAsync(int? id, string searchString, bool includeInactive)
        {
            
            CurrentFilter = searchString;
            IncludeDeleted = includeInactive;
            

            IQueryable<Initiative> initiativeIq = from s in _context.Initiative
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                initiativeIq = initiativeIq.Where(s => s.ResourceNavigation.FirstName.Contains(searchString));
            }

            if (!includeInactive)
            {
                initiativeIq = initiativeIq.Where(s => s.IsActive);
            }
           

            Initiative = await initiativeIq
               .Include(i => i.LocationNavigation)
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation)
                .OrderBy(i => i.ReceiveDate)
                .ToListAsync();
            if (id != null)
            {
                InitativeId = id.Value;
            }
        }
    }
}
