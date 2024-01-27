using MicroXYZ.Database;
using System.Collections.Generic;

namespace MicroXYZ.Areas.AdminPanel.Models
{
    public class ProductCreateOrUpdateViewModel
    {
        public Product Product { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
