using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class AboutPageSetting : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(100)"))]
        public string Title { get; set; }
        
        public string Image { get; set; }
        
        [Required]
        public string Title2 { get; set; }
        
        public string Description { get; set; }

        [Required]
        public string CallToActionTitle { get; set; }
        
        public string CallToActionDescription { get; set; }
        
        public string CallToActionButtonText { get; set; }        
    }
}
