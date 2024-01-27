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
    public class ContactFormSubjectController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public ContactFormSubjectController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var contactFormSubjects = await _context.ContactFormSubjects.ToListAsync();

            ViewBag.IsActive = true;

            return View(contactFormSubjects);
        }

        public async Task<IActionResult> CreateOrUpdateContactFormSubject(int id)
        {
            ContactFormSubject contactFormSubject = new ContactFormSubject();

            if (id > 0)
            {
                contactFormSubject = await _context.ContactFormSubjects.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(contactFormSubject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateContactFormSubject(ContactFormSubject contactFormSubject)
        {
            if (ModelState.IsValid)
            {
                if (contactFormSubject.Id == 0)
                {
                    _context.ContactFormSubjects.Add(contactFormSubject);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.Contact_Form_Subject_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminContactFormSubjects");
                }

                else
                {
                    var contactFormSubjectUpdate = await _context.ContactFormSubjects.FirstOrDefaultAsync(x => x.Id == contactFormSubject.Id);

                    if (contactFormSubjectUpdate != null)
                    {
                        contactFormSubjectUpdate.Name = contactFormSubject.Name;
                        contactFormSubjectUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.Contact_Form_Subject_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminContactFormSubjects");
                    }
                }
            }

            return View(contactFormSubject);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteContactFormSubject(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var contactFormSubject = await _context.ContactFormSubjects.FirstOrDefaultAsync(x => x.Id == id);

                if (contactFormSubject != null)
                {
                    contactFormSubject.IsActive = isActive;
                    contactFormSubject.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Contact_Form_Subject_Restore_Delete.ToString() : ResultModelEnum.Contact_Form_Subject_Deleted.ToString(), isActive ? (int)ResultModelEnum.Contact_Form_Subject_Restore_Delete : (int)ResultModelEnum.Contact_Form_Subject_Deleted, isActive ? contactFormSubject : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Contact_Form_Subject_Not_Found.ToString(), (int)ResultModelEnum.Contact_Form_Subject_Not_Found);
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
