using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.EAInvolvements
{
    public class EditModel : PageModel
    {
        private readonly InitiativeContext _context;

        public EditModel(InitiativeContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EAInvolvement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EAInvolvementExists(EAInvolvement.EAInvolvementId))
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

        private bool EAInvolvementExists(int id)
        {
            return _context.EAInvolvement.Any(e => e.EAInvolvementId == id);
        }
    }
}
