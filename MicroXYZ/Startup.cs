using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MicroXYZ.Database;
using MicroXYZ.Helpers;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroXYZ
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<MicroXYZDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MicroXYZConnection")));

            services.AddScoped<IWordHelper, WordHelper>();
            services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();
            services.AddScoped<IResultModelHelper, ResultModelHelper>();
            services.AddScoped<IFileHelper, FileHelper>();
            services.AddScoped<IEmailHelper, EmailHelper>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // cookie transaction services

            services.Configure<CookiePolicyOptions>(options => // coocike write to user pc transaction services
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "ADMIN_AUTHENTICATION";
                options.LoginPath = "/admin/login"; // authentication yoksa yönlendirilecek yer
                options.ExpireTimeSpan = TimeSpan.FromDays(30); // oturum süresi ayarý
                options.SlidingExpiration = false; // oturum süresi boyunca yeni istek gelir veya iþlem yapýlýrsa oturum süresi sýfýrlanýr.
                options.AccessDeniedPath = "/admin/login"; // authentication yoksa yönlendirilecek yer
            });

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                CloseButton = true,
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseNToastNotify();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "/",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "singleProduct",
                    pattern: "/product/{id?}",
                    defaults: new { controller = "Home", action = "SingleProduct" });

                endpoints.MapControllerRoute(
                    name: "singleProductBuy",
                    pattern: "/product/single-product-buy",
                    defaults: new { controller = "Home", action = "SingleProduct" });

                endpoints.MapAreaControllerRoute(
                    name: "adminPanel",
                    areaName: "adminpanel",
                    pattern: "/admin",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminLogin",
                    areaName: "adminpanel",
                    pattern: "/admin/login",
                    defaults: new { controller = "Admin", action = "Login" });

                endpoints.MapAreaControllerRoute(
                    name: "adminHomePageSettings",
                    areaName: "adminpanel",
                    pattern: "/admin/home-page-settings",
                    defaults: new { controller = "HomePageSetting", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminHomePageSettingEdit",
                    areaName: "adminpanel",
                    pattern: "/admin/home-page-setting-edit/{id?}",
                    defaults: new { controller = "HomePageSetting", action = "CreateOrUpdateHomePageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminHomePageSettingDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/home-page-setting-delete",
                    defaults: new { controller = "HomePageSetting", action = "DeleteOrRestoreDeleteHomePageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminServices",
                    areaName: "adminpanel",
                    pattern: "/admin/services",
                    defaults: new { controller = "Service", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminServiceCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/service-edit/{id?}",
                    defaults: new { controller = "Service", action = "CreateOrUpdateService" });

                endpoints.MapAreaControllerRoute(
                    name: "adminServiceDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/service-delete",
                    defaults: new { controller = "Service", action = "DeleteOrRestoreDeleteService" });

                endpoints.MapAreaControllerRoute(
                    name: "adminSocialMediaLinks",
                    areaName: "adminpanel",
                    pattern: "/admin/social-media-links",
                    defaults: new { controller = "SocialMediaLink", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminSocialMediaLinkCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/socail-media-link-edit/{id?}",
                    defaults: new { controller = "SocialMediaLink", action = "CreateOrUpdateSocailMediaLink" });

                endpoints.MapAreaControllerRoute(
                    name: "adminSocialMediaLinkDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/social-media-link-delete",
                    defaults: new { controller = "SocialMediaLink", action = "DeleteOrRestoreDeleteSocialMediaLink" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactPageSettings",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-page-settings",
                    defaults: new { controller = "ContactPageSetting", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactPageSettingCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-page-setting-edit/{id?}",
                    defaults: new { controller = "ContactPageSetting", action = "CreateOrUpdateContactPageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactPageSettingDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-page-setting-delete",
                    defaults: new { controller = "ContactPageSetting", action = "DeleteOrRestoreDeleteContactPageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactFormSubjects",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-form-subjects",
                    defaults: new { controller = "ContactFormSubject", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactFormSubjectCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-form-subject-edit/{id?}",
                    defaults: new { controller = "ContactFormSubject", action = "CreateOrUpdateContactFormSubject" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactFormSubjectDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-form-subject-delete",
                    defaults: new { controller = "ContactFormSubject", action = "DeleteOrRestoreDeleteContactFormSubject" });

                endpoints.MapAreaControllerRoute(
                    name: "adminContactForms",
                    areaName: "adminpanel",
                    pattern: "/admin/contact-forms",
                    defaults: new { controller = "ContactForm", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductCategories",
                    areaName: "adminpanel",
                    pattern: "/admin/product-categories",
                    defaults: new { controller = "ProductCategory", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductCategoryCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/product-category-edit/{id?}",
                    defaults: new { controller = "ProductCategory", action = "CreateOrUpdateProductCategory" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductCategoryDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/product-category-delete",
                    defaults: new { controller = "ProductCategory", action = "DeleteOrRestoreDeleteProductCategory" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProducts",
                    areaName: "adminpanel",
                    pattern: "/admin/products",
                    defaults: new { controller = "Product", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/product-edit/{id?}",
                    defaults: new { controller = "Product", action = "CreateOrUpdateProduct" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/product-delete",
                    defaults: new { controller = "Product", action = "DeleteOrRestoreDeleteProduct" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductImageDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/product-image-delete",
                    defaults: new { controller = "Product", action = "DeleteOrRestoreDeleteProductImage" });

                endpoints.MapAreaControllerRoute(
                    name: "adminProductImageMakeBannerPhoto",
                    areaName: "adminpanel",
                    pattern: "/admin/product-image-make-banner-photo",
                    defaults: new { controller = "Product", action = "MakeBannerPhotoToSelectedPhoto" });

                endpoints.MapAreaControllerRoute(
                    name: "adminPanelAdmin",
                    areaName: "adminpanel",
                    pattern: "/admin/admins",
                    defaults: new { controller = "Admin", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAdminCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/admin-edit/{id?}",
                    defaults: new { controller = "Admin", action = "CreateOrUpdateAdmin" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAdminDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/admin-delete",
                    defaults: new { controller = "Admin", action = "DeleteOrRestoreDeleteAdmin" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutPageSettings",
                    areaName: "adminpanel",
                    pattern: "/admin/about-page-settings",
                    defaults: new { controller = "AboutPageSetting", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutPageSettingCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/about-page-setting-edit/{id?}",
                    defaults: new { controller = "AboutPageSetting", action = "CreateOrUpdateAboutPageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutPageSettingDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/about-page-delete",
                    defaults: new { controller = "AboutPageSetting", action = "DeleteOrRestoreDeleteAboutPageSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutItems",
                    areaName: "adminpanel",
                    pattern: "/admin/about-items",
                    defaults: new { controller = "AboutItem", action = "Index" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutItemCreateOrUpdate",
                    areaName: "adminpanel",
                    pattern: "/admin/about-item-edit/{id?}",
                    defaults: new { controller = "AboutItem", action = "CreateOrUpdateAboutItemSetting" });

                endpoints.MapAreaControllerRoute(
                    name: "adminAboutItemDeleteOrRestoreDelete",
                    areaName: "adminpanel",
                    pattern: "/admin/about-item-delete",
                    defaults: new { controller = "AboutItem", action = "DeleteOrRestoreDeleteAboutItem" });

                //endpoints.MapAreaControllerRoute(
                //    name: "firstAdminCreate",
                //    areaName: "adminpanel",
                //    pattern: "/admin/first-admin",
                //    defaults: new { controller = "Admin", action = "CreateFirstAdmin" });
            });
        }
    }
}
