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
       [Required]
        [Column("Note")]
        public string Note1 { get; set; }
        [Required]
        [Column(TypeName = "nchar(150)")]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [ForeignKey("NoteId")]
        [InverseProperty("Note")]
        public Initiative Initiative { get; set; }
    }
}
