using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Initiatives.Models
{
    public partial class Initiative : LastModified
    {
        public Initiative()
        {
            InitiativeMetaTag = new HashSet<InitiativeMetaTag>();
        }

        [Key]
        public int InitiativeId { get; set; }
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        [StringLength(200, MinimumLength = 3)]
        public string EngagementName { get; set; }
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Identifier")]
        public string EngagementIdentifier { get; set; }
        [Display(Name = "Engagement")]
        public int? EngagementTypeId { get; set; }
        [Display(Name = "CurrentStatus")]
        public int? CurrentStatusId { get; set; }
        [Display(Name = "Solution")]
        public int? SolutionTypeId { get; set; }
        [Display(Name = "Deployment")]
        public int? LocationId { get; set; }
        [Display(Name = "PHI")]
        public bool PHI { get; set; }
        [Display(Name = "PCI")]
        public bool PCI { get; set; }
        [Display(Name = "Upstream System")]
        [StringLength(200, MinimumLength = 3)]
        public string UpStreamSystem { get; set; }
        [StringLength(200, MinimumLength = 3)]
        [Display(Name = "Downstream System")]
        public string DownStreamSystem { get; set; }
        [Display(Name = "Project Start")]
        [DataType(DataType.Date)]
        public DateTime? ProjectStartDate { get; set; }
        [Display(Name = "ARB")]
        [DataType(DataType.Date)]
        public DateTime? ARBDate { get; set; }
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
        [Display(Name = "Deployment")]
        public Location LocationNavigation { get; set; }
        [Display(Name = "Engagement")]
        public EngagementType EngagementTypeNavigation { get; set; }
        [Display(Name = "Architect")]
        public Resource ResourceNavigation { get; set; }
        [Display(Name = "Solution")]
        public SolutionType SolutionTypeNavigation { get; set; }
        [Display(Name = "Status")]
        public CurrentStatus CurrentStatusNavigation { get; set; }
        [Display(Name = "Meta Tags")]
        public ICollection<InitiativeMetaTag> InitiativeMetaTag { get; set; }
        [Display(Name = "COE")]
        public ICollection<InitiativeBusiness> InitiativeBusiness { get; set; }
        [Display(Name = "Facility")]
        public ICollection<InitiativeFacility> InitiativeFacility { get; set; }
        //[InverseProperty("NoteNavigation")]
        public ICollection<Note> Note { get; set; }
    }
}
