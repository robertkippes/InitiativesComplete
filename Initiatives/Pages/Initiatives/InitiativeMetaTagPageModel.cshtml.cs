using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Initiatives.Models;
using Initiatives.Models.ViewModels;



namespace Initiatives.Pages.Initiatives
{
    public class InitiativeMetaTagPageModel : PageModel
    {
        public List<AssignedMetaTagData> AssignedMetaTagDataList;

        public void PopulateAssignedMetaTagData(InitiativeContext context,
                                               Initiative initiative)
        {
            var allMetaTag = context.MetaTag;
            var initiativeMetaTags = new HashSet<int>(
                initiative.InitiativeMetaTag.Select(c => c.MetaTagId));
            AssignedMetaTagDataList = new List<AssignedMetaTagData>();
            foreach (var metaTag in allMetaTag)
            {
                AssignedMetaTagDataList.Add(new AssignedMetaTagData
                {
                    MetaTagId = metaTag.MetaTagId,
                    MetaTagDescription = metaTag.MetaTagDescription,
                    Assigned = initiativeMetaTags.Contains(metaTag.MetaTagId)
                });
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
                            {InitiativeId = initiativeToUpdate.InitiativeId,
                                MetaTagId= metaTag.MetaTagId
                            });
                    }
                }
                else
                {
                    //THis is the delete a meta tag conditon
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
