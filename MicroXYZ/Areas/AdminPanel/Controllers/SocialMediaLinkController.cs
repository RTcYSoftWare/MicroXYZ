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
    public class SocialMediaLinkController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public SocialMediaLinkController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var socialMediaLinks = await _context.SocialMediaLinks.ToListAsync();

            ViewBag.IsActive = true;

            return View(socialMediaLinks);
        }

        public async Task<IActionResult> CreateOrUpdateSocailMediaLink(int id)
        {
            SocialMediaLink socialMediaLink = new SocialMediaLink();

            if (id > 0)
            {
                socialMediaLink = await _context.SocialMediaLinks.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(socialMediaLink);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateSocailMediaLink(SocialMediaLink socialMediaLink)
        {
            if (ModelState.IsValid)
            {
                if (socialMediaLink.Id == 0)
                {
                    _context.SocialMediaLinks.Add(socialMediaLink);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Social Media Link Oluşturuldu !", new ToastrOptions()
                    {
                        Title = "Başarılı !"
                    });

                    return RedirectToRoute("adminSocialMediaLinks");
                }

                else
                {
                    var socialMediaLinkUpdate = await _context.SocialMediaLinks.FirstOrDefaultAsync(x => x.Id == socialMediaLink.Id);

                    if (socialMediaLinkUpdate != null)
                    {
                        socialMediaLinkUpdate.Title = socialMediaLink.Title;
                        socialMediaLinkUpdate.Icon = socialMediaLink.Icon;
                        socialMediaLinkUpdate.Url = socialMediaLink.Url;
                        socialMediaLinkUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage("Social Media Link Güncellendi !", new ToastrOptions()
                        {
                            Title = "Başarılı !"
                        });

                        return RedirectToRoute("adminSocialMediaLinks");
                    }
                }
            }

            return View(socialMediaLink);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteSocialMediaLink(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var socialMediaLink = await _context.SocialMediaLinks.FirstOrDefaultAsync(x => x.Id == id);

                if (socialMediaLink != null)
                {
                    socialMediaLink.IsActive = isActive;
                    socialMediaLink.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Social_Media_Link_Restore_Delete.ToString() : ResultModelEnum.Social_Media_Link_Deleted.ToString(), isActive ? (int)ResultModelEnum.Social_Media_Link_Restore_Delete : (int)ResultModelEnum.Social_Media_Link_Deleted, isActive ? socialMediaLink : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Social_Media_Link_Not_Found.ToString(), (int)ResultModelEnum.Social_Media_Link_Not_Found);
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
