using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class Product : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(50)"))]
        public string Title { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        public string Description { get; set; }

        [Column(TypeName = ("decimal(18,2)"))]
        public decimal Price { get; set; }        

        public int ProductCategoryId { get; set; }

        public ProductCategory ProductCategory { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
