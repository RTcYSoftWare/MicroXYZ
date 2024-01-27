using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class SocialMediaLink : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(50)"))]
        public string Title { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }
    }
}
