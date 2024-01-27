using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public class HomePageSettingController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;
        private readonly IFileHelper _fileHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public HomePageSettingController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification, IFileHelper fileHelper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
            _fileHelper = fileHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var homePageSettings = await _context.HomePageSettings.ToListAsync();

            ViewBag.IsActive = true;

            return View(homePageSettings);
        }

        public async Task<IActionResult> CreateOrUpdateHomePageSetting(int id)
        {
            // TODO: view tarafına img seçme ve controller tarafına da file save eklenecek.

            HomePageSetting homePageSetting = new HomePageSetting();

            if (id > 0)
            {
                homePageSetting = await _context.HomePageSettings.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(homePageSetting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateHomePageSetting(HomePageSetting homePageSetting, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                if (homePageSetting.Id == 0)
                {
                    if (formFile != null)
                    {
                        var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-images");
                        
                        if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                        {
                            homePageSetting.Image = fileResult.Data.ToString();
                        }
                    }

                    _context.HomePageSettings.Add(homePageSetting);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Home Page Setting Oluşturuldu !", new ToastrOptions()
                    {
                        Title = "Başarılı !"
                    });

                    return RedirectToRoute("adminHomePageSettings");
                }

                else
                {
                    var homePageSettingUpdate = await _context.HomePageSettings.FirstOrDefaultAsync(x => x.Id == homePageSetting.Id);

                    if (homePageSettingUpdate != null)
                    {
                        homePageSettingUpdate.Title = homePageSetting.Title;
                        homePageSettingUpdate.Description = homePageSetting.Description;
                        homePageSettingUpdate.Video = homePageSetting.Video;
                        homePageSettingUpdate.UpdatedAt = DateTime.Now;

                        if (formFile != null)
                        {
                            var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-images");

                            if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                            {
                                homePageSettingUpdate.Image = fileResult.Data.ToString();
                            }
                        }

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage("Home Page Setting Güncellendi !", new ToastrOptions()
                        {
                            Title = "Başarılı !"
                        });
                    }
                }
            }
            return View(homePageSetting);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteHomePageSetting(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var homePageSetting = await _context.HomePageSettings.FirstOrDefaultAsync(x => x.Id == id);

                if (homePageSetting != null)
                {
                    homePageSetting.IsActive = isActive;
                    homePageSetting.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Home_Page_Setting_Restore_Delete.ToString() : ResultModelEnum.Home_Page_Setting_Deleted.ToString(), isActive ? (int)ResultModelEnum.Home_Page_Setting_Restore_Delete : (int)ResultModelEnum.Home_Page_Setting_Deleted, isActive ? homePageSetting : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Home_Page_Setting_Not_Found.ToString(), (int)ResultModelEnum.Home_Page_Setting_Not_Found);
                }
            }

            else
            {
                resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Transaction_Error.ToString(), (int)ResultModelEnum.Transaction_Error);
            }

            return resultModel;
        }
    }
}
