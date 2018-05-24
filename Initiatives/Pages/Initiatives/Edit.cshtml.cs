using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Initiatives
{
    public class EditModel : PageModel
    {
        private readonly InitiativeContext _context;

        public EditModel(InitiativeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Initiative = await _context.Initiative
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.LocationNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation).SingleOrDefaultAsync(m => m.InitiativeId == id);

            if (Initiative == null)
            {
                return NotFound();
            }
           ViewData["EngagementTypeId"] = new SelectList(_context.EngagementType, "EngagementTypeId", "EngagementTypeDescription");
           ViewData["LocationId"] = new SelectList(_context.DeploymentLocation, "LocationId", "LocationDescription");
           ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");
           ViewData["SolutionTypeId"] = new SelectList(_context.SolutionType, "SolutionTypeId", "ModifiedUserName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Initiative).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InitiativeExists(Initiative.InitiativeId))
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

        private bool InitiativeExists(int id)
        {
            return _context.Initiative.Any(e => e.InitiativeId == id);
        }
    }
}
