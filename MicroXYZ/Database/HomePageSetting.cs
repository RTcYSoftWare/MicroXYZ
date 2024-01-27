using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class HomePageSetting : BaseEntity
    {
        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Description { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Video { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Image { get; set; }
    }
}
