using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Facilities
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<Facility> Facility { get;set; }

        public async Task OnGetAsync()
        {
            //Facility = await _context.Facility.ToListAsync();
            IQueryable<Facility> facilityIq = from s in _context.Facility
                                                    select s;
            facilityIq = facilityIq.Where(s => s.IsActive).AsNoTracking();
            Facility = await facilityIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();
        }
    }
}
