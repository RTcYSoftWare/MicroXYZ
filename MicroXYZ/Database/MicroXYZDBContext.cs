using Microsoft.EntityFrameworkCore;

namespace MicroXYZ.Database
{
    public class MicroXYZDBContext : DbContext
    {
        public MicroXYZDBContext(DbContextOptions<MicroXYZDBContext> options) : base(options)
        {

        }

        public DbSet<HomePageSetting> HomePageSettings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContactPageSetting> ContactPageSettings { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<ContactFormSubject> ContactFormSubjects { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AboutPageSetting> AboutPageSettings { get; set; }
        public DbSet<AboutItem> AboutItems { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailSmtpsetting> EmailSmtpsettings { get; set; }
        public DbSet<EmailSent> EmailSents { get; set; }
        public DbSet<EmailSendError> EmailSendErrors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HomePageSetting>().ToTable("HomePageSettings");
            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ContactPageSetting>().ToTable("ContactPageSettings");
            modelBuilder.Entity<ContactForm>().ToTable("ContactForms");
            modelBuilder.Entity<ContactFormSubject>().ToTable("ContactFormSubjects");
            modelBuilder.Entity<SocialMediaLink>().ToTable("SocialMediaLinks");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<AboutPageSetting>().ToTable("AboutPageSettings");
            modelBuilder.Entity<AboutItem>().ToTable("AboutItems");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImages");
            modelBuilder.Entity<EmailTemplate>().ToTable("EmailTemplates");
            modelBuilder.Entity<EmailSmtpsetting>().ToTable("EmailSmtpsettings");
            modelBuilder.Entity<EmailSent>().ToTable("EmailSents");
            modelBuilder.Entity<EmailSendError>().ToTable("EmailSendErrors");
        }
    }
}
