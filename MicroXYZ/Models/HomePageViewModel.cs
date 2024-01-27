using MicroXYZ.Database;
using System.Collections.Generic;

namespace MicroXYZ.Models
{
    public class HomePageViewModel
    {
        public HomePageSetting HomePageSetting { get; set; }
        public List<Service> Services { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products { get; set; }
        public ContactPageSetting ContactPageSetting { get; set; }
        public List<ContactFormSubject> ContactFormSubjects { get; set; }
        public List<SocialMediaLink> SocialMediaLinks { get; set; }
        public ContactFormPostModel ContactFormPostModel { get; set; }
        public AboutPageSetting AboutPageSetting { get; set; }
        public List<AboutItem> AboutItems { get; set; }
    }
}
