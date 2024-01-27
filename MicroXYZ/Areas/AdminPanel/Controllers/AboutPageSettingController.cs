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
using System.Threading.Tasks;

namespace MicroXYZ.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class AboutPageSettingController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;
        private readonly IFileHelper _fileHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public AboutPageSettingController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification, IFileHelper fileHelper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
            _fileHelper = fileHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var aboutPageSettings = await _context.AboutPageSettings.ToListAsync();

            ViewBag.IsActive = true;

            return View(aboutPageSettings);
        }

        public async Task<IActionResult> CreateOrUpdateAboutPageSetting(int id)
        {
            AboutPageSetting aboutPageSetting = new AboutPageSetting();

            if (id > 0)
            {
                aboutPageSetting = await _context.AboutPageSettings.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(aboutPageSetting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAboutPageSetting(AboutPageSetting aboutPageSetting, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                if (aboutPageSetting.Id == 0)
                {
                    if (formFile != null)
                    {
                        var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-images");

                        if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                        {
                            aboutPageSetting.Image = fileResult.Data.ToString();
                        }
                    }

                    _context.AboutPageSettings.Add(aboutPageSetting);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.About_Page_Setting_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminAboutPageSettings");
                }

                else
                {
                    var aboutPageSettingUpdate = await _context.AboutPageSettings.FirstOrDefaultAsync(x => x.Id == aboutPageSetting.Id);

                    if (aboutPageSettingUpdate != null)
                    {
                        aboutPageSettingUpdate.Title = aboutPageSetting.Title;
                        aboutPageSettingUpdate.Description = aboutPageSetting.Description;
                        aboutPageSettingUpdate.Title2 = aboutPageSetting.Title2;
                        aboutPageSettingUpdate.CallToActionTitle = aboutPageSetting.CallToActionTitle;
                        aboutPageSettingUpdate.CallToActionDescription = aboutPageSetting.CallToActionDescription;
                        aboutPageSettingUpdate.CallToActionButtonText = aboutPageSetting.CallToActionButtonText;

                        if (formFile != null)
                        {
                            var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-images");

                            if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                            {
                                aboutPageSettingUpdate.Image = fileResult.Data.ToString();
                            }
                        }

                        aboutPageSettingUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.About_Page_Setting_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminAboutPageSettings");
                    }
                }
            }

            return View(aboutPageSetting);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteAboutPageSetting(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var aboutPageSetting = await _context.AboutPageSettings.FirstOrDefaultAsync(x => x.Id == id);

                if (aboutPageSetting != null)
                {
                    aboutPageSetting.IsActive = isActive;
                    aboutPageSetting.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.About_Page_Setting_Restore_Delete.ToString() : ResultModelEnum.About_Page_Setting_Deleted.ToString(), isActive ? (int)ResultModelEnum.About_Page_Setting_Restore_Delete : (int)ResultModelEnum.About_Page_Setting_Deleted, isActive ? aboutPageSetting : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.About_Page_Setting_Not_Found.ToString(), (int)ResultModelEnum.About_Page_Setting_Not_Found);
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
