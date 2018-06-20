using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.CurrentStatuses
{
    public class DeleteModel : PageModel
    {
        private readonly InitiativeContext _context;

    public DeleteModel(InitiativeContext context)
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

            CurrentStatus = await _context.CurrentStatus.FindAsync(id);

        if (CurrentStatus != null)
        {
            _context.CurrentStatus.Remove(CurrentStatus);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
}