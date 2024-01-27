using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class ProductCategory : BaseEntity
    {
        [Required]
        [Column(TypeName = ("varchar(50)"))]
        public string Title { get; set; }

        public int Sequence { get; set; }
    }
}
