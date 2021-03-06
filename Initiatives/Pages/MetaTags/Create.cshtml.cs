using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Initiatives.Models;

namespace Initiatives.Pages.MetaTags
{
    public class CreateModel : PageModel
    {
        private readonly Initiatives.Models.InitiativeContext _context;

        public CreateModel(Initiatives.Models.InitiativeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MetaTag MetaTag { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MetaTag.Add(MetaTag);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}