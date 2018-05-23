using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Initiatives.Models
{
    public partial class Initiative
    {
        public Initiative()
        {
            InitiativeMetaTag = new HashSet<InitiativeMetaTag>();
        }

        public bool IsActive { get; set; }
        public int InitiativeId { get; set; }
        [Display(Name = "Initiative Name")]
        [DataType(DataType.Text)]
        public string EngagementName { get; set; }
        [Display(Name = "Engagement Identifier")]
        public string EngagementIdentifier { get; set; }
        [Display(Name = "Engagement Type")]
        public int? EngagementType { get; set; }
        [Display(Name = "Solution Type")]
        public int? SolutionType { get; set; }
        [Display(Name = "Business")]
        public int? Business { get; set; }
        [Display(Name = "Deployment Location")]
        public int? DeploymentLocation { get; set; }
        [Display(Name = "PHI")]
        public bool PHI { get; set; }
        [Display(Name = "PCI")]
        public bool PCI { get; set; }
        [Display(Name = "Upstream System")]
        public string UpStreamSystem { get; set; }
        [Display(Name = "Downstream System")]
        public string DownStreamSystem { get; set; }
        [Display(Name = "Facility")]
        public int? Facility { get; set; }
        [Display(Name = "Project Start")]
        [DataType(DataType.Date)]
        public DateTime? ProjectStartDate { get; set; }
        [Display(Name = "ARB Date")]
        [DataType(DataType.Date)]
        public DateTime? ARBdate { get; set; }
        public int? Resource { get; set; }
        [Display(Name = "Received")]
        [DataType(DataType.Date)]
        public DateTime? ReceiveDate { get; set; }
        [Display(Name = "EA Start")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "EA Complete")]
        [DataType(DataType.Date)]
        public DateTime? CompleteDate { get; set; }
        [Display(Name = "Location")]
        public Location LocationNavigation { get; set; }
        [Display(Name = "Engagement Type")]
        public EngagementType EngagementTypeNavigation { get; set; }
        [Display(Name = "Architect")]
        public Resource ResourceNavigation { get; set; }
        [Display(Name = "Solution Type")]
        public SolutionType SolutionTypeNavigation { get; set; }
        [Display(Name = "Meta Tags")]
        public ICollection<InitiativeMetaTag> InitiativeMetaTag { get; set; }
        public ICollection<Business> BusinessNavigation { get; set; }
        [Display(Name = "Facility")]
        public ICollection<Facility> FacilityNavigation { get; set; }
        [InverseProperty("NoteNavigation")]
        public Note Note { get; set; }
    }
}
