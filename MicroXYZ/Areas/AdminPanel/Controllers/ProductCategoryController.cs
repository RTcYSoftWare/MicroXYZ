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
    public class ProductCategoryController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;


        public ProductCategoryController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var productCategories = await _context.ProductCategories.ToListAsync();

            ViewBag.IsActive = true;

            return View(productCategories);
        }

        public async Task<IActionResult> CreateOrUpdateProductCategory(int id)
        {
            ProductCategory productCategory = new ProductCategory();

            if (id > 0)
            {
                productCategory = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProductCategory(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                if (productCategory.Id == 0)
                {
                    _context.ProductCategories.Add(productCategory);

                    await _context.SaveChangesAsync();

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.Product_Category_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminProductCategories");
                }

                else
                {
                    var productCategoryUpdate = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategory.Id);

                    if (productCategoryUpdate != null)
                    {
                        productCategoryUpdate.Title = productCategory.Title;
                        productCategoryUpdate.Sequence = productCategory.Sequence;
                        productCategoryUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.Product_Category_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminProductCategories");
                    }
                }
            }

            return View(productCategory);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteProductCategory(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);

                if (productCategory != null)
                {
                    productCategory.IsActive = isActive;
                    productCategory.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Product_Category_Restore_Delete.ToString() : ResultModelEnum.Product_Category_Deleted.ToString(), isActive ? (int)ResultModelEnum.Product_Category_Restore_Delete : (int)ResultModelEnum.Product_Category_Deleted, isActive ? productCategory : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Product_Category_Not_Found.ToString(), (int)ResultModelEnum.Product_Category_Not_Found);
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
