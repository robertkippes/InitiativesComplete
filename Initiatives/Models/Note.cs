using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Initiatives.Models
{
    public partial class Note : LastModified
    {
        [Key]
        public int NoteId { get; set; }
        public int InitiativeId { get; set; }
        [Display(Name = "Note")]
        [Required]
        [Column("Note")]
        public string Note1 { get; set; }
        [Display(Name = "Created by")]
        [Required]
        [Column(TypeName = "varchar(150)")]
        public string UserName { get; set; }
        [Display(Name = "Created Date")]
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Initiative Name")]
        [ForeignKey("InitiativeId")]
        [InverseProperty("Note")]
        public Initiative InitiativeNavigation { get; set; }
    }
}
