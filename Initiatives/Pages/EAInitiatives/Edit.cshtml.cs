using Initiatives.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Initiatives.Pages.EAInitiatives
{
    public class EditModel : InitiativePageModel
    {
        private readonly Initiatives.Models.InitiativeContext _context;

        public EditModel(Initiatives.Models.InitiativeContext context)
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
            ViewData["LocationId"] = new SelectList(_context.DeploymentLocation, "LocationId", "LocationDescription");
            ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");
            ViewData["SolutionTypeId"] = new SelectList(_context.SolutionType, "SolutionTypeId", "SolutionTypeDescription");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedBusiness, string[] selectedFacility, string[] selectedMetaTags)
        {
            if (!ModelState.IsValid)
            {
                return Page();            }
            
            _context.Attach(Initiative).State = EntityState.Modified;
            //This saves the parent Entity and onoe-many child relationships
            await _context.SaveChangesAsync();
            
            //This saves the Masny-to-Many relationships
            var initiativeToUpdate = await _context.Initiative
                .Include(i => i.InitiativeBusiness)
                .ThenInclude(i => i.Business)
                .Include(i => i.InitiativeFacility)
                .ThenInclude(i => i.Facility)
                .Include(i => i.InitiativeMetaTag)
                    .ThenInclude(i => i.MetaTag)
                .FirstOrDefaultAsync(s => s.InitiativeId == id);

            UpdateInitiativeBusiness(_context, selectedBusiness, initiativeToUpdate);
            UpdateInitiativeFacility(_context, selectedFacility, initiativeToUpdate);
            UpdateInitiativeMetaTags(_context, selectedMetaTags, initiativeToUpdate);
            
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