using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class AboutItem : BaseEntity
    {        
        [Required]
        [Column(TypeName = ("varchar(50)"))]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(200)"))]
        public string Description { get; set; }
        
        public string Icon { get; set; }
    }
}
