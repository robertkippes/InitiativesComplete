using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Initiatives
{
    public class DeleteModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DeleteModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Initiative = await _context.Initiative
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.LocationNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation).SingleOrDefaultAsync(m => m.InitiativeId == id);

            if (Initiative == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Initiative = await _context.Initiative.FindAsync(id);

            if (Initiative != null)
            {
                _context.Initiative.Remove(Initiative);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
