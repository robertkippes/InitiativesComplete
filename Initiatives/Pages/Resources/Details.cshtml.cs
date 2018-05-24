using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Resources
{
    public class DetailsModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DetailsModel(InitiativeContext context)
        {
            _context = context;
        }

        public Resource Resource { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Resource = await _context.Resource.SingleOrDefaultAsync(m => m.ResourceId == id);

            if (Resource == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
