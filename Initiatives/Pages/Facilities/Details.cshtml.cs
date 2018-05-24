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
    public class DetailsModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DetailsModel(InitiativeContext context)
        {
            _context = context;
        }

        public Facility Facility { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Facility = await _context.Facility.SingleOrDefaultAsync(m => m.FacilityId == id);

            if (Facility == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
