using Microsoft.AspNetCore.Authorization;
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
    public class AboutItemController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public AboutItemController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {            
            // TODO: iconları selectbox yap.

            var aboutItems = await _context.AboutItems.ToListAsync();

            ViewBag.IsActive = true;

            return View(aboutItems);
        }

        public async Task<IActionResult> CreateOrUpdateAboutItemSetting(int id)
        {
            AboutItem aboutItem = new AboutItem();            

            if (id > 0)
            {
                aboutItem = await _context.AboutItems.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(aboutItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateAboutItemSetting(AboutItem aboutItem)
        {
            if (ModelState.IsValid)
            {
                if (aboutItem.Id == 0)
                {
                    _context.AboutItems.Add(aboutItem);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.About_Item_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminAboutItems");
                }

                else
                {
                    var aboutItemUpdate = await _context.AboutItems.FirstOrDefaultAsync(x => x.Id == aboutItem.Id);

                    if (aboutItemUpdate != null)
                    {
                        aboutItemUpdate.Title = aboutItem.Title;
                        aboutItemUpdate.Description = aboutItem.Description;
                        aboutItemUpdate.Icon = aboutItem.Icon;
                        aboutItem.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.About_Item_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminAboutItems");
                    }
                }
            }

            return View(aboutItem);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteAboutItem(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var aboutItem = await _context.AboutItems.FirstOrDefaultAsync(x => x.Id == id);

                if (aboutItem != null)
                {
                    aboutItem.IsActive = isActive;
                    aboutItem.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.About_Item_Restore_Delete.ToString() : ResultModelEnum.About_Item_Deleted.ToString(), isActive ? (int)ResultModelEnum.About_Item_Restore_Delete : (int)ResultModelEnum.About_Item_Deleted, isActive ? aboutItem : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.About_Item_Not_Found.ToString(), (int)ResultModelEnum.About_Item_Not_Found);
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
