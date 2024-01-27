using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class ContactForm : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(100)"))]
        public string NameSurname { get; set; }

        [Required]
        [Column(TypeName = ("varchar(50)"))]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = ("varchar(MAX)"))]
        public string Message { get; set; }

        public int ContactFormSubjectId { get; set; }        
    }
}
