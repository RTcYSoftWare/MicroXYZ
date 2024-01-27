using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class Service : BaseEntity
    {
        [Column(TypeName = ("varchar(50)"))]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Description { get; set; }

        public string Icon { get; set; }
    }
}
