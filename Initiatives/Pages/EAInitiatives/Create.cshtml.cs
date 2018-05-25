using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Initiatives.Models;

namespace Initiatives.Pages.EAInitiatives
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
        ViewData["EngagementTypeId"] = new SelectList(_context.EngagementType, "EngagementTypeId", "EngagementTypeDescription");
        ViewData["LocationId"] = new SelectList(_context.DeploymentLocation, "LocationId", "LocationDescription");
        ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");
        ViewData["SolutionTypeId"] = new SelectList(_context.SolutionType, "SolutionTypeId", "ModifiedUserName");
            return Page();
        }

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Initiative.Add(Initiative);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}