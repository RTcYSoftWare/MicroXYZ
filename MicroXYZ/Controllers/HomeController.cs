using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroXYZ.Database;
using MicroXYZ.Enums;
using MicroXYZ.Helpers;
using MicroXYZ.Models;
using System;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MicroXYZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IEmailHelper _emailHelper;

        public HomeController(MicroXYZDBContext context, IEmailHelper emailHelper)
        {
            _context = context;
            _emailHelper = emailHelper;
        }

        public async Task<IActionResult> Index()
        {
            // TODO: viewstart'a db modelleri using edilecek.
            // TODO: homepage slider için resim yükleme işlemleri yapılacak.
            // TODO: products lar için galeri yapılacak.
            // TODO: products kısmında hepsine basınca hepsi gelmiyor.
            // TODO: contact form bağlanacak. 
            // TODO: email gönderme işlemeleri yapılacak.
            // TODO: admin tarafında icon kullanılan yerlerde icon enum yapılacak. oradan seçim yaptırılacak.


            HomePageViewModel homePageViewModel = new HomePageViewModel();

            homePageViewModel.HomePageSetting = await _context.HomePageSettings.FirstOrDefaultAsync(x => x.IsActive);
            homePageViewModel.Services = await _context.Services.Where(x => x.IsActive == true).ToListAsync();
            homePageViewModel.ProductCategories = await _context.ProductCategories.Where(x => x.IsActive == true).OrderBy(x => x.Sequence).ToListAsync();
            homePageViewModel.Products = await _context.Products.Where(x => x.IsActive == true).Include(x => x.ProductImages.Where(x => x.IsBanner && x.IsActive)).ToListAsync();
            homePageViewModel.ContactPageSetting = await _context.ContactPageSettings.FirstOrDefaultAsync(x => x.IsActive == true);
            homePageViewModel.ContactFormSubjects = await _context.ContactFormSubjects.Where(x => x.IsActive == true).ToListAsync();
            //homePageViewModel.ContactFormPostModel = new ContactFormPostModel();            
            homePageViewModel.AboutPageSetting = await _context.AboutPageSettings.FirstOrDefaultAsync(x => x.IsActive);
            homePageViewModel.AboutItems = await _context.AboutItems.Where(x => x.IsActive).ToListAsync();

            return View(homePageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormPostModel contactFormPostModel)
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();

            homePageViewModel.HomePageSetting = await _context.HomePageSettings.FirstOrDefaultAsync(x => x.IsActive);
            homePageViewModel.Services = await _context.Services.Where(x => x.IsActive == true).ToListAsync();
            homePageViewModel.ProductCategories = await _context.ProductCategories.Where(x => x.IsActive == true).OrderBy(x => x.Sequence).ToListAsync();
            homePageViewModel.Products = await _context.Products.Where(x => x.IsActive == true).Include(x => x.ProductImages.Where(x => x.IsBanner && x.IsActive)).ToListAsync();
            homePageViewModel.ContactPageSetting = await _context.ContactPageSettings.FirstOrDefaultAsync(x => x.IsActive == true);
            homePageViewModel.ContactFormSubjects = await _context.ContactFormSubjects.Where(x => x.IsActive == true).ToListAsync();
            homePageViewModel.AboutPageSetting = await _context.AboutPageSettings.FirstOrDefaultAsync(x => x.IsActive);
            homePageViewModel.AboutItems = await _context.AboutItems.Where(x => x.IsActive).ToListAsync();
            homePageViewModel.ContactFormPostModel = contactFormPostModel;

            if (ModelState.IsValid)
            {
                ContactForm contactForm = new ContactForm();

                contactForm.NameSurname = contactFormPostModel.NameSurname;
                contactForm.Email = contactFormPostModel.Email;
                contactForm.Message = contactFormPostModel.Message;
                contactForm.ContactFormSubjectId = contactFormPostModel.SubjectId;

                _context.ContactForms.Add(contactForm);

                await _context.SaveChangesAsync();

                EmailBodyHelper emailBodyHelper = new EmailBodyHelper();

                emailBodyHelper.RecieverName = contactForm.NameSurname;
                emailBodyHelper.RecieverEmail = contactForm.Email;
                emailBodyHelper.ContactFormMessage = contactFormPostModel.Message;
                var subject = await _context.ContactFormSubjects.FirstOrDefaultAsync(x => x.Id == contactForm.ContactFormSubjectId);
                emailBodyHelper.Subject = subject.Name;

                await _emailHelper.SendEmailAsync("info.microxyz@gmail.com", EMailSMTPTemplatesEnum.CONTACT_US_FORM_TEMPLATE.ToString(), EMailSMTPSettingsEnum.SMTP_EPOSTA_FORGET_PASSWORD_HTML_TEMPLATE.ToString(), emailBodyHelper);

                if (contactForm.Id > 0)
                {
                    ViewBag.ContactFormSuccess = true;
                }

                else
                {
                    ViewBag.ContactFormSuccess = false;
                }
            }

            return View(homePageViewModel);
        }

        public async Task<IActionResult> SingleProduct(int id)
        {
            Product product = new Product();

            if (id > 0)
            {
                product = await _context.Products.Include(x => x.ProductImages.Where(x => x.IsActive)).FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            }

            return View(product);
        }

        [HttpPost]
        public async Task<ResultModel> SingleProduct(int id, string nameSurname, string email, string phone)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0 && nameSurname != null && IsValidEmail(email))
            {
                EmailBodyHelper emailBodyHelper = new EmailBodyHelper();

                emailBodyHelper.RecieverName = nameSurname;
                emailBodyHelper.RecieverEmail = email;
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
                emailBodyHelper.ProductName = product.Title;
                emailBodyHelper.ProductInfo = product.Title + " " + product.Price + " " + product.Description;
                emailBodyHelper.RecieverPhone = phone;

                await _emailHelper.SendEmailAsync("info.microxyz@gmail.com", EMailSMTPTemplatesEnum.PRODUCT_BUY_REQUEST_TEMPLATE.ToString(), EMailSMTPSettingsEnum.SMTP_EPOSTA_FORGET_PASSWORD_HTML_TEMPLATE.ToString(), emailBodyHelper);

                await _emailHelper.SendEmailAsync(email, EMailSMTPTemplatesEnum.PRODUCT_BUY_CUSTOMER_TEMPLATE.ToString(), EMailSMTPSettingsEnum.SMTP_EPOSTA_FORGET_PASSWORD_HTML_TEMPLATE.ToString(), emailBodyHelper);

                resultModel.Code = (int)ResultModelEnum.Transaction_Success;
                resultModel.Message = ResultModelEnum.Transaction_Success.ToString();
            }

            else
            {
                resultModel.Code = (int)ResultModelEnum.Transaction_Error;
                resultModel.Message = ResultModelEnum.Transaction_Error.ToString();
            }

            return resultModel;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
