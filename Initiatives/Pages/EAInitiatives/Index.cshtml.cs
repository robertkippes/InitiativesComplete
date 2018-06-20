using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Initiatives.Pages.EAInitiatives
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }


        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }
        public bool IncludeDeleted { get; set; }
        public int InitativeId { get; set; }
        //public IList<Initiative> Initiative { get;set; }
        public PaginatedList<Initiative> Initiative { get; set; }

        public async Task OnGetAsync(int? id, int? pageIndex, string searchString, string currentFilter, bool includeInactive, string sortOrder)
        {
            CurrentSort = sortOrder;
            NameSort = sortOrder == "Name" ? "name_desc" : "Name";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            IncludeDeleted = includeInactive;
            ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");

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
            switch (sortOrder)
            {
                case "name_desc":
                    initiativeIq = initiativeIq.OrderByDescending(s => s.ResourceNavigation.FirstName);
                    break;
                case "Name":
                    initiativeIq = initiativeIq.OrderBy(s => s.ResourceNavigation.FirstName);
                    break;
                case "Date":
                    initiativeIq = initiativeIq.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    initiativeIq = initiativeIq.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    initiativeIq = initiativeIq.OrderBy(s => s.ReceiveDate);
                    break;
            }

            initiativeIq = initiativeIq
                .Include(i => i.LocationNavigation)
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation)
                .AsNoTracking();

            int pageSize = 3;

            Initiative = await PaginatedList<Initiative>.CreateAsync(initiativeIq, pageIndex ?? 1, pageSize);


            //Initiative = await initiativeIq
            //   .Include(i => i.LocationNavigation)
            //    .Include(i => i.EngagementTypeNavigation)
            //    .Include(i => i.ResourceNavigation)
            //    .Include(i => i.SolutionTypeNavigation)
            //    //.OrderBy(i => i.ReceiveDate)
            //    .ToListAsync();
            //if (id != null)
            //{
            //    InitativeId = id.Value;
            //}
        }
    }
}
