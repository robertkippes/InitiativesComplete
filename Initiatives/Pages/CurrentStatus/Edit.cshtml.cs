using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.CurrentStatuses
{
    public class EditModel : PageModel
    {
        private readonly InitiativeContext _context;

        public EditModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CurrentStatus CurrentStatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CurrentStatus = await _context.CurrentStatus.SingleOrDefaultAsync(m => m.CurrentStatusId == id);

            if (CurrentStatus == null)
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

            _context.Attach(CurrentStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrentStatusExists(CurrentStatus.CurrentStatusId))
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

        private bool CurrentStatusExists(int id)
        {
            return _context.CurrentStatus.Any(e => e.CurrentStatusId == id);
        }
    }
}
