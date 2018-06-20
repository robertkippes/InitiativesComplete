using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Initiatives.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Initiatives.Pages.CurrentStatuses
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
            return Page();
        }

        [BindProperty]
        public CurrentStatus CurrentStatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CurrentStatus.Add(CurrentStatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}