using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class ContactFormSubject : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(100)"))]
        public string Name { get; set; }
    }
}
