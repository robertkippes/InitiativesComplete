using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Initiatives.Models;

namespace Initiatives.Pages.Businesses
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
        public Business Business { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Business.Add(Business);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}