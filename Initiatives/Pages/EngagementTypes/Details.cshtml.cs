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
    public class DetailsModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DetailsModel(InitiativeContext context)
        {
            _context = context;
        }

        public EngagementType EngagementType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EngagementType = await _context.EngagementType.SingleOrDefaultAsync(m => m.EngagementTypeId == id);

            if (EngagementType == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
