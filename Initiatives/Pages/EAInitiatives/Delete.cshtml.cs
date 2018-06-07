using Initiatives.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Initiatives.Pages.EAInitiatives
{
    public class DeleteModel : InitiativePageModel
    {
        private readonly Initiatives.Models.InitiativeContext _context;

        public DeleteModel(Initiatives.Models.InitiativeContext context)
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
                .Include(i => i.InitiativeBusiness).ThenInclude(i => i.Business)
                .Include(i => i.InitiativeFacility).ThenInclude(i => i.Facility)
                .Include(i => i.InitiativeMetaTag).ThenInclude(i => i.MetaTag)
                .Include(i => i.EngagementTypeNavigation)
                .Include(i => i.LocationNavigation)
                .Include(i => i.ResourceNavigation)
                .Include(i => i.SolutionTypeNavigation).SingleOrDefaultAsync(m => m.InitiativeId == id);

            if (Initiative == null)
            {
                return NotFound();
            }
            PopulateAssignedBusinessData(_context, Initiative);
            PopulateAssignedFacilityData(_context, Initiative);
            PopulateAssignedMetaTagData(_context, Initiative);
            ViewData["EngagementTypeId"] = new SelectList(_context.EngagementType, "EngagementTypeId", "EngagementTypeDescription");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationDescription");
            ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");
            ViewData["SolutionTypeId"] = new SelectList(_context.SolutionType, "SolutionTypeId", "SolutionTypeDescription");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Initiative = await _context.Initiative.FindAsync(id);

            if (Initiative != null)
            {
                _context.Initiative.Remove(Initiative);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}