using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives;
using Initiatives.Models;

namespace Initiatives.Pages.Notes
{
    public class DetailsModel : PageModel
    {
        private readonly InitiativeContext _context;

        public DetailsModel(InitiativeContext context)
        {
            _context = context;
        }

        public Note Note { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Note = await _context.Note
                .Include(n => n.InitiativeNavigation).SingleOrDefaultAsync(m => m.NoteId == id);

            if (Note == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
