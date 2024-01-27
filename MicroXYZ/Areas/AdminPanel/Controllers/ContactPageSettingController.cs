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
    public class ContactPageSettingController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public ContactPageSettingController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var contactPageSettings = await _context.ContactPageSettings.ToListAsync();

            ViewBag.IsActive = true;

            return View(contactPageSettings);
        }

        public async Task<IActionResult> CreateOrUpdateContactPageSetting(int id)
        {
            // TODO: harita düzelene kadar kapatılacak. sonra google maps eklenecek.

            ContactPageSetting contactPageSetting = new ContactPageSetting();

            if (id > 0)
            {
                contactPageSetting = await _context.ContactPageSettings.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(contactPageSetting);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateContactPageSetting(ContactPageSetting contactPageSetting)
        {
            if (ModelState.IsValid)
            {
                if (contactPageSetting.Id == 0)
                {
                    _context.ContactPageSettings.Add(contactPageSetting);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.Contact_Page_Setting_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminContactPageSettings");
                }

                else
                {
                    var contactPageSettingUpdate = await _context.ContactPageSettings.FirstOrDefaultAsync(x => x.Id == contactPageSetting.Id);

                    if (contactPageSettingUpdate != null)
                    {
                        contactPageSettingUpdate.Title = contactPageSetting.Title;
                        contactPageSettingUpdate.Description = contactPageSetting.Description;
                        contactPageSettingUpdate.Address = contactPageSetting.Address;
                        contactPageSettingUpdate.Phone = contactPageSetting.Phone;
                        contactPageSettingUpdate.Email = contactPageSetting.Email;
                        contactPageSettingUpdate.Fax = contactPageSetting.Fax;
                        contactPageSettingUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.Contact_Page_Setting_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminContactPageSettings");
                    }
                }
            }

            return View(contactPageSetting);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteContactPageSetting(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var contactPageSetting = await _context.ContactPageSettings.FirstOrDefaultAsync(x => x.Id == id);

                if (contactPageSetting != null)
                {
                    contactPageSetting.IsActive = isActive;
                    contactPageSetting.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Contact_Page_Setting_Restore_Delete.ToString() : ResultModelEnum.Contact_Page_Setting_Deleted.ToString(), isActive ? (int)ResultModelEnum.Contact_Page_Setting_Restore_Delete : (int)ResultModelEnum.Contact_Page_Setting_Deleted, isActive ? contactPageSetting : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Contact_Page_Setting_Not_Found.ToString(), (int)ResultModelEnum.Contact_Page_Setting_Not_Found);
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
