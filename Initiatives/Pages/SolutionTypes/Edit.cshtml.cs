using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.SolutionTypes
{
    public class EditModel : PageModel
    {
        private readonly InitiativeContext _context;

        public EditModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SolutionType SolutionType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SolutionType = await _context.SolutionType.SingleOrDefaultAsync(m => m.SolutionTypeId == id);

            if (SolutionType == null)
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

            _context.Attach(SolutionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionTypeExists(SolutionType.SolutionTypeId))
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

        private bool SolutionTypeExists(int id)
        {
            return _context.SolutionType.Any(e => e.SolutionTypeId == id);
        }
    }
}
