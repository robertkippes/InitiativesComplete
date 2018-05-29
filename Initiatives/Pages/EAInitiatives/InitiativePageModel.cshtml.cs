using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Initiatives.Models;
using Initiatives.Models.ViewModels;


namespace Initiatives.Pages.EAInitiatives
{
    public class InitiativePageModel : PageModel
    {
        
        public List<AssignedBusiness> AssignedBusinessDataList;
        public List<AssignedFacility> AssignedFacilityDataList;
        public List<AssignedMetaTag> AssignedMetaTagDataList;

        public void PopulateAssignedBusinessData(InitiativeContext context,
                                               Initiative initiative)
        {
            //Get all posible tages
            var allBusiness = context.Business;
            //get the relationship tables
            var initiativeBusiness = new HashSet<int>(
                initiative.InitiativeBusiness.Select(c => c.BusinessId));
            //Create the assigned list
            AssignedBusinessDataList = new List<AssignedBusiness>();
            //Add each Meta Tag to list if it occurs in the join table
            foreach (var business in allBusiness)
            {
                AssignedBusinessDataList.Add(new AssignedBusiness
                {
                    BusinessId = business.BusinessId,
                    BusinessDescription = business.BusinessDescription,
                    Assigned = initiativeBusiness.Contains(business.BusinessId)
                });
            }
        }

        public void PopulateAssignedFacilityData(InitiativeContext context,
            Initiative initiative)
        {
            //Get all posible tages
            var allFacility = context.Facility;
            //get the relationship tables
            var initiativeFacility = new HashSet<int>(
                initiative.InitiativeFacility.Select(c => c.FacilityId));
            //Create thew assigned list
            AssignedFacilityDataList = new List<AssignedFacility>();
            //Add each Meta Tag to list if it occurs in the join table
            foreach (var facility in allFacility)
            {
                AssignedFacilityDataList.Add(new AssignedFacility
                {
                    FacilityId = facility.FacilityId,
                    FacilityDescription = facility.FacilityDescription,
                    Assigned = initiativeFacility.Contains(facility.FacilityId)
                });
            }
        }

        public void PopulateAssignedMetaTagData(InitiativeContext context,
            Initiative initiative)
        {
            //Get all posible tages
            var allMetaTag = context.MetaTag;
            //get the relationship tables
            var initiativeMetaTags = new HashSet<int>(
                initiative.InitiativeMetaTag.Select(c => c.MetaTagId));
            //Create thew assigned list
            AssignedMetaTagDataList = new List<AssignedMetaTag>();
            //Add each Meta Tag to list if it occurs in the join table
            foreach (var metaTag in allMetaTag)
            {
                AssignedMetaTagDataList.Add(new AssignedMetaTag
                {
                    MetaTagId = metaTag.MetaTagId,
                    MetaTagDescription = metaTag.MetaTagDescription,
                    Assigned = initiativeMetaTags.Contains(metaTag.MetaTagId)
                });
            }
        }

        public void UpdateInitiativeBusiness(InitiativeContext context,
            string[] selectedBusiness, Initiative initiativeToUpdate)
        {
            if (selectedBusiness == null)
            {
                initiativeToUpdate.InitiativeBusiness = new List<InitiativeBusiness>();
                return;
            }

            var selectedBusinessHS = new HashSet<string>(selectedBusiness);
            var initiativeBusiness = new HashSet<int>
                (initiativeToUpdate.InitiativeBusiness.Select(c => c.Business.BusinessId));
            foreach (var business in context.Business)
            {
                // This is the add a meta tag condition from UI
                if (selectedBusinessHS.Contains(business.BusinessId.ToString()))
                {
                    if (!initiativeBusiness.Contains(business.BusinessId))
                    {
                        initiativeToUpdate.InitiativeBusiness.Add
                            (
                            new InitiativeBusiness
                            {
                                InitiativeId = initiativeToUpdate.InitiativeId,
                                BusinessId = business.BusinessId
                            });
                    }
                }
                else
                {
                    //This is the delete a meta tag conditon
                    if (initiativeBusiness.Contains(business.BusinessId))
                    {
                        InitiativeBusiness businessToRemove
                            = initiativeToUpdate
                                .InitiativeBusiness
                                .SingleOrDefault(i => i.BusinessId == business.BusinessId);
                        context.Remove(businessToRemove);
                    }
                }
            }
        }

        public void UpdateInitiativeFacility(InitiativeContext context,
            string[] selectedFacility, Initiative initiativeToUpdate)
        {
            if (selectedFacility == null)
            {
                initiativeToUpdate.InitiativeFacility = new List<InitiativeFacility>();
                return;
            }

            var selectedFacilityHS = new HashSet<string>(selectedFacility);
            var initiativeFacilitys = new HashSet<int>
                (initiativeToUpdate.InitiativeFacility.Select(c => c.Facility.FacilityId));
            foreach (var facility in context.Facility)
            {
                // This is the add a meta tag condition from UI
                if (selectedFacilityHS.Contains(facility.FacilityId.ToString()))
                {
                    if (!initiativeFacilitys.Contains(facility.FacilityId))
                    {
                        initiativeToUpdate.InitiativeFacility.Add
                        (
                            new InitiativeFacility
                            {
                                InitiativeId = initiativeToUpdate.InitiativeId,
                                FacilityId = facility.FacilityId
                            });
                    }
                }
                else
                {
                    //This is the delete a meta tag conditon
                    if (initiativeFacilitys.Contains(facility.FacilityId))
                    {
                        InitiativeFacility facilityToRemove
                            = initiativeToUpdate
                                .InitiativeFacility
                                .SingleOrDefault(i => i.FacilityId == facility.FacilityId);
                        context.Remove(facilityToRemove);
                    }
                }
            }
        }

        public void UpdateInitiativeMetaTags(InitiativeContext context,
            string[] selectedMetaTags, Initiative initiativeToUpdate)
        {
            if (selectedMetaTags == null)
            {
                initiativeToUpdate.InitiativeMetaTag = new List<InitiativeMetaTag>();
                return;
            }

            var selectedMetaTagsHS = new HashSet<string>(selectedMetaTags);
            var initiativeMetaTags = new HashSet<int>
                (initiativeToUpdate.InitiativeMetaTag.Select(c => c.MetaTag.MetaTagId));
            foreach (var metaTag in context.MetaTag)
            {
                // This is the add a meta tag condition from UI
                if (selectedMetaTagsHS.Contains(metaTag.MetaTagId.ToString()))
                {
                    if (!initiativeMetaTags.Contains(metaTag.MetaTagId))
                    {
                        initiativeToUpdate.InitiativeMetaTag.Add
                        (
                            new InitiativeMetaTag
                            {
                                InitiativeId = initiativeToUpdate.InitiativeId,
                                MetaTagId = metaTag.MetaTagId
                            });
                    }
                }
                else
                {
                    //This is the delete a meta tag conditon
                    if (initiativeMetaTags.Contains(metaTag.MetaTagId))
                    {
                        InitiativeMetaTag metaTagToRemove
                            = initiativeToUpdate
                                .InitiativeMetaTag
                                .SingleOrDefault(i => i.MetaTagId == metaTag.MetaTagId);
                        context.Remove(metaTagToRemove);
                    }
                }
            }
        }
    }
}
