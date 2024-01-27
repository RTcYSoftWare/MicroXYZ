using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class ContactPageSetting : BaseEntity
    {
        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Description { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Address { get; set; }

        [Column(TypeName = ("varchar(20)"))]
        public string Phone { get; set; }

        [Column(TypeName = ("varchar(20)"))]
        public string Fax { get; set; }

        [Column(TypeName = ("varchar(50)"))]
        public string Email { get; set; }
    }
}
