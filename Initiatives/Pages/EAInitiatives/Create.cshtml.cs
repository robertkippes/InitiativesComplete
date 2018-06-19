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
    public class CreateModel : InitiativePageModel
    {
        private readonly Initiatives.Models.InitiativeContext _context;

        public CreateModel(Initiatives.Models.InitiativeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var initiative = new Initiative();
            // Build META Tag List
            initiative.InitiativeMetaTag = new List<InitiativeMetaTag>();
            // Provides an empty collection for the foreach loop
            // in the Create Razor page.
            PopulateAssignedMetaTagData(_context, initiative);
            //Build Business List
            initiative.InitiativeBusiness = new List<InitiativeBusiness>();
            PopulateAssignedBusinessData(_context, initiative);
            //Build Facility List
            initiative.InitiativeFacility = new List<InitiativeFacility>();
            PopulateAssignedFacilityData(_context, initiative);

            // Continue with one to one relationships
            ViewData["EngagementTypeId"] = new SelectList(_context.EngagementType, "EngagementTypeId", "EngagementTypeDescription");
        ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationDescription");
        ViewData["Resource"] = new SelectList(_context.Resource, "ResourceId", "FirstName");
        ViewData["SolutionTypeId"] = new SelectList(_context.SolutionType, "SolutionTypeId", "SolutionTypeDescription");
            return Page();
        }

        [BindProperty]
        public Initiative Initiative { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedBusiness, string[] selectedFacility, string[] selectedMetaTags)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            /*******************************************/

            //Get the entity
            var newInitiative = new Initiative();
            // Add Business
            if (selectedBusiness != null)
            {
                newInitiative.InitiativeBusiness = new List<InitiativeBusiness>();
                foreach (var business in selectedBusiness)
                {
                    var initiativeBusinessToAdd = new InitiativeBusiness
                    {
                        BusinessId = int.Parse(business)
                    };
                    newInitiative.InitiativeBusiness.Add(initiativeBusinessToAdd);
                }
            }
            // Add Facility
            if (selectedFacility != null)
            {
                newInitiative.InitiativeFacility = new List<InitiativeFacility>();
                foreach (var facility in selectedFacility)
                {
                    var initiativeFacilityToAdd = new InitiativeFacility
                    {
                        FacilityId = int.Parse(facility)
                    };
                    newInitiative.InitiativeFacility.Add(initiativeFacilityToAdd);
                }
            }


            // Add Meta Tags
            if (selectedMetaTags != null)
            {
                newInitiative.InitiativeMetaTag = new List<InitiativeMetaTag>();
                foreach (var metaTag in selectedMetaTags)
                {
                    var initiativeMetaTagToAdd = new InitiativeMetaTag
                    {
                        MetaTagId = int.Parse(metaTag)
                    };
                    newInitiative.InitiativeMetaTag.Add(initiativeMetaTagToAdd);
                }
            }
            
            // Add Facility
            //the method of updating below is used as a security measure and to prevent over posting
            if (await TryUpdateModelAsync<Initiative>(
                newInitiative,
                "Initiative",
                i => i.ARBDate,
                i => i.EngagementName,
                i => i.EngagementIdentifier,
                i => i.EngagementTypeId,
                i => i.SolutionTypeId,
                i => i.LocationId,
                i => i.PHI,
                i => i.PCI,
                i => i.UpStreamSystem,
                i => i.DownStreamSystem,
                i => i.ProjectStartDate,
                i => i.Resource,
                i => i.ReceiveDate,
                i => i.StartDate,
                i => i.CompleteDate,
                i => i.LastModifiedDate,
                i => i.ModifiedUserName,
                i => i.IsActive))
            {
                _context.Initiative.Add(newInitiative);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedMetaTagData(_context, newInitiative);
            return Page();


            /***************************************
            _context.Initiative.Add(Initiative);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}