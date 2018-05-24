using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EngagementTypes
{
    public class EditModel : PageModel
    {
        private readonly InitiativeContext _context;

        public EditModel(InitiativeContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EngagementType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementTypeExists(EngagementType.EngagementTypeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EngagementTypeExists(int id)
        {
            return _context.EngagementType.Any(e => e.EngagementTypeId == id);
        }
    }
}
