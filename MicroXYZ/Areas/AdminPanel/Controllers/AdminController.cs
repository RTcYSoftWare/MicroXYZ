using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroXYZ.Areas.AdminPanel.Models;
using MicroXYZ.Database;
using MicroXYZ.Enums;
using MicroXYZ.Helpers;
using MicroXYZ.Models;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MicroXYZ.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IWordHelper _wordHelper;
        private readonly IAuthenticationHelper _authenticationHelper;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public AdminController(MicroXYZDBContext context, IWordHelper wordHelper, IAuthenticationHelper authenticationHelper, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _wordHelper = wordHelper;
            _authenticationHelper = authenticationHelper;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var admins = await _context.Admins.ToListAsync();

            ViewBag.IsActive = true;

            return View(admins);
        }

        public async Task<IActionResult> CreateOrUpdateAdmin(int id)
        {
            Admin admin = new Admin();

            if (id > 0)
            {
                admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id == id);                
            }

            return View(admin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                if (admin.Id == 0)
                {
                    admin.Guid = Guid.NewGuid();
                    admin.SecretKey = Guid.NewGuid();
                    admin.Password = _wordHelper.HashToText(admin.Password, admin.SecretKey.ToString());

                    _context.Admins.Add(admin);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.Admin_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminPanelAdmin");
                }

                else
                {
                    var adminUpdate = await _context.Admins.FirstOrDefaultAsync(x => x.Id == admin.Id);

                    if (adminUpdate != null)
                    {
                        adminUpdate.Name = admin.Name;
                        adminUpdate.Surname = admin.Surname;
                        adminUpdate.Email = admin.Email;
                        adminUpdate.Phone = admin.Phone;

                        if (adminUpdate.Password != admin.Password)
                        {
                            adminUpdate.Password = _wordHelper.HashToText(admin.Password, admin.SecretKey.ToString());
                        }
                        
                        adminUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.Admin_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminPanelAdmin");
                    }
                }
            }

            return View(admin);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteAdmin(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id == id);

                if (admin != null)
                {
                    admin.IsActive = isActive;
                    admin.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Admin_Restore_Delete.ToString() : ResultModelEnum.Admin_Deleted.ToString(), isActive ? (int)ResultModelEnum.Admin_Restore_Delete : (int)ResultModelEnum.Admin_Deleted, isActive ? admin : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Admin_Not_Found.ToString(), (int)ResultModelEnum.Admin_Not_Found);
                }
            }

            else
            {
                resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Transaction_Error.ToString(), (int)ResultModelEnum.Transaction_Error);
            }

            return resultModel;
        }


        [AllowAnonymous]
        public IActionResult Login()
        {
            AdminLoginViewModel adminLoginViewModel = new AdminLoginViewModel();

            return View(adminLoginViewModel);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Email == adminLoginViewModel.Email && x.IsActive == true);

                if (admin != null)
                {
                    if (admin.Password == _wordHelper.HashToText(adminLoginViewModel.Password, admin.SecretKey.ToString()))
                    {
                        await _authenticationHelper.CookieAuthentication(admin);

                        if (!string.IsNullOrEmpty(adminLoginViewModel.ReturnUrl))
                        {
                            return Redirect(adminLoginViewModel.ReturnUrl);
                        }

                        else
                        {
                            return RedirectToRoute("adminPanel");
                        }
                    }
                }
            }

            return View(adminLoginViewModel);
        }


        //[AllowAnonymous]
        //public async Task<IActionResult> CreateFirstAdmin()
        //{
        //    Admin admin = new Admin();

        //    admin.Name = "Rıza Turancan";
        //    admin.Surname = "YILMAZ";
        //    admin.Email = "turancanyl@gmail.com";
        //    admin.Phone = "05555555555";
        //    admin.Guid = Guid.NewGuid();
        //    admin.SecretKey = Guid.NewGuid();
        //    admin.Password = _wordHelper.HashToText("88726789t", admin.SecretKey.ToString());

        //    Admin admin2 = new Admin();

        //    admin2.Name = "Ali Oğuzhan";
        //    admin2.Surname = "YILMAZ";
        //    admin2.Email = "ogidesign.od@gmail.com";
        //    admin2.Phone = "05555555555";
        //    admin2.Guid = Guid.NewGuid();
        //    admin2.SecretKey = Guid.NewGuid();
        //    admin2.Password = _wordHelper.HashToText("123456789", admin2.SecretKey.ToString());

        //    _context.Admins.Add(admin);
        //    _context.Admins.Add(admin2);

        //    await _context.SaveChangesAsync();

        //    return View();
        //}
    }
}
