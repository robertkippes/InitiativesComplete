using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;
using Initiatives.Models.ViewModels;

namespace Initiatives.Pages.Initiatives
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
        public InitativesMetaTagsIndexData Initiative { get; set; }
        public async Task OnGetAsync(int? id, string searchString, bool includeInactive)
        {
            CurrentFilter = searchString;
            IncludeDeleted = includeInactive;
            Initiative = new InitativesMetaTagsIndexData();

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

            Initiative.Initiatives = await initiativeIq
                .Include(i => i.InitiativeBusiness)
                    .ThenInclude(i => i.Business)
                .Include(i => i.InitiativeFacility)
                    .ThenInclude(i => i.Facility)
                .Include(i => i.InitiativeMetaTag)
                    .ThenInclude(i => i.MetaTag)
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.LocationNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation).ToListAsync();
           
            
            

        }
    }
}
