using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class ProductImage : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(MAX)"))]
        public string Image { get; set; }
        public bool IsBanner { get; set; } = false;
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
