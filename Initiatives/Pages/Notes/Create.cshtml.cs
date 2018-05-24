using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Initiatives;
using Initiatives.Models;

namespace Initiatives.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly InitiativeContext _context;

        public CreateModel(InitiativeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["NoteId"] = new SelectList(_context.Initiative, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}