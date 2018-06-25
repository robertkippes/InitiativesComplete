using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EAInvolvements
{
    public class DeleteModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DeleteModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EAInvolvement EAInvolvement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EAInvolvement = await _context.EAInvolvement.SingleOrDefaultAsync(m => m.EAInvolvementId == id);

            if (EAInvolvement == null)
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

            EAInvolvement = await _context.EAInvolvement.FindAsync(id);

            if (EAInvolvement != null)
            {
                _context.EAInvolvement.Remove(EAInvolvement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
