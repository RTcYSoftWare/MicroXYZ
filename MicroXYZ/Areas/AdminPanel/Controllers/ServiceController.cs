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
    public class ServiceController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;
        private readonly IFileHelper _fileHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ServiceController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification, IFileHelper fileHelper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
            _fileHelper = fileHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();

            ViewBag.IsActive = true;

            return View(services);
        }

        public async Task<IActionResult> CreateOrUpdateService(int id)
        {
            Service service = new Service();

            if (id > 0)
            {
                service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateService(Service service, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                if (service.Id == 0)
                {
                    if (formFile != null)
                    {
                        var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-icons");

                        if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                        {
                            service.Icon = fileResult.Data.ToString();
                        }
                    }

                    _context.Services.Add(service);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage("Service Created !", new ToastrOptions()
                    {
                        Title = "Başarılı !"
                    });

                    return RedirectToRoute("adminServices");
                }

                else
                {
                    var serviceUpdate = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);

                    if (serviceUpdate != null)
                    {
                        serviceUpdate.Title = service.Title;
                        serviceUpdate.Description = service.Description;                        
                        serviceUpdate.UpdatedAt = DateTime.Now;

                        if (formFile != null)
                        {
                            var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "page-icons");

                            if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                            {
                                serviceUpdate.Icon = fileResult.Data.ToString();
                            }
                        }

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage("Service Updated !", new ToastrOptions()
                        {
                            Title = "Başarılı !"
                        });

                        return RedirectToRoute("adminServices");
                    }

                    else
                    {
                        return RedirectToRoute("adminServices");
                    }
                }
            }

            return View(service);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteService(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

                if (service != null)
                {
                    service.IsActive = isActive;
                    service.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Service_Restore_Delete.ToString() : ResultModelEnum.Service_Deleted.ToString(), isActive ? (int)ResultModelEnum.Service_Restore_Delete : (int)ResultModelEnum.Service_Deleted, isActive ? service : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Service_Not_Found.ToString(), (int)ResultModelEnum.Service_Not_Found);
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
