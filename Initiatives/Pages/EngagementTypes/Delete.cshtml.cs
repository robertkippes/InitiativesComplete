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
    public class DeleteModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DeleteModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EngagementType = await _context.EngagementType.FindAsync(id);

            if (EngagementType != null)
            {
                _context.EngagementType.Remove(EngagementType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
