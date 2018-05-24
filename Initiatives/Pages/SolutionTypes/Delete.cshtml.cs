using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.SolutionTypes
{
    public class DeleteModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DeleteModel(InitiativeContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SolutionType = await _context.SolutionType.FindAsync(id);

            if (SolutionType != null)
            {
                _context.SolutionType.Remove(SolutionType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
