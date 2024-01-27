using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroXYZ.Areas.AdminPanel.Models;
using MicroXYZ.Database;
using MicroXYZ.Enums;
using MicroXYZ.Helpers;
using MicroXYZ.Models;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroXYZ.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly MicroXYZDBContext _context;
        private readonly IResultModelHelper _resultModelHelper;
        private readonly IToastNotification _toastNotification;
        private readonly IFileHelper _fileHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ProductController(MicroXYZDBContext context, IResultModelHelper resultModelHelper, IToastNotification toastNotification, IFileHelper fileHelper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _resultModelHelper = resultModelHelper;
            _toastNotification = toastNotification;
            _fileHelper = fileHelper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();

            ViewBag.IsActive = true;

            return View(products);
        }

        public async Task<IActionResult> CreateOrUpdateProduct(int id)
        {
            ProductCreateOrUpdateViewModel productCreateOrUpdateViewModel = new ProductCreateOrUpdateViewModel();
            productCreateOrUpdateViewModel.Product = new Product();
            productCreateOrUpdateViewModel.ProductCategories = await _context.ProductCategories.Where(x => x.IsActive).OrderBy(x => x.Sequence).ToListAsync();

            if (id > 0)
            {
                productCreateOrUpdateViewModel.Product = await _context.Products.Include(x => x.ProductImages.Where(x => x.IsActive)).FirstOrDefaultAsync(x => x.Id == id);
            }

            return View(productCreateOrUpdateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdateProduct(Product product, List<IFormFile> formFiles)
        {
            // TODO: make product galery & single product page to customer pages

            ProductCreateOrUpdateViewModel productCreateOrUpdateViewModel = new ProductCreateOrUpdateViewModel();

            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                    //product.Price = Convert.ToDecimal(product.Price.ToString().Split(",")[1]);

                    _context.Products.Add(product);

                    await _context.SaveChangesAsync();

                    if (formFiles.Any())
                    {
                        foreach (var formFile in formFiles)
                        {
                            var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "product-images");

                            if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                            {
                                ProductImage productImage = new ProductImage();
                                productImage.ProductId = product.Id;
                                productImage.Image = fileResult.Data.ToString();

                                _context.ProductImages.Add(productImage);

                                await _context.SaveChangesAsync();
                            }
                        }
                    }

                    _toastNotification.AddSuccessToastMessage(ResultModelEnum.Product_Created.ToString().Replace("_", " "), new ToastrOptions()
                    {
                        Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                    });

                    return RedirectToRoute("adminProducts");
                }

                else
                {
                    var productUpdate = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);

                    if (productUpdate != null)
                    {
                        productUpdate.Title = product.Title;
                        productUpdate.Description = product.Description;
                        productUpdate.Price = product.Price;
                        productUpdate.ProductCategoryId = product.ProductCategoryId;
                        productUpdate.UpdatedAt = DateTime.Now;

                        await _context.SaveChangesAsync();

                        if (formFiles.Any())
                        {
                            foreach (var formFile in formFiles)
                            {
                                var fileResult = await _fileHelper.SaveFiles(_webHostEnvironment, formFile, "product-images");

                                if (fileResult.Code == (int)ResultModelEnum.IForm_File_Saved)
                                {
                                    ProductImage productImage = new ProductImage();
                                    productImage.ProductId = productUpdate.Id;
                                    productImage.Image = fileResult.Data.ToString();

                                    _context.ProductImages.Add(productImage);

                                    await _context.SaveChangesAsync();
                                }
                            }
                        }

                        _toastNotification.AddSuccessToastMessage(ResultModelEnum.Product_Updated.ToString().Replace("_", " "), new ToastrOptions()
                        {
                            Title = ResultModelEnum.Transaction_Success.ToString().Replace("_", " "),
                        });

                        return RedirectToRoute("adminProducts");
                    }
                }
            }

            else
            {
                productCreateOrUpdateViewModel.Product = product;
                productCreateOrUpdateViewModel.ProductCategories = await _context.ProductCategories.Where(x => x.IsActive).OrderBy(x => x.Sequence).ToListAsync();
            }

            return View(productCreateOrUpdateViewModel);
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteProduct(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product != null)
                {
                    product.IsActive = isActive;
                    product.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Product_Restore_Delete.ToString() : ResultModelEnum.Product_Deleted.ToString(), isActive ? (int)ResultModelEnum.Product_Restore_Delete : (int)ResultModelEnum.Product_Deleted, isActive ? product : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Product_Not_Found.ToString(), (int)ResultModelEnum.Product_Not_Found);
                }
            }

            else
            {
                resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Transaction_Error.ToString(), (int)ResultModelEnum.Transaction_Error);
            }

            return resultModel;
        }

        [HttpPost]
        public async Task<ResultModel> DeleteOrRestoreDeleteProductImage(int id, bool isActive)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0)
            {
                var productImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == id);

                if (productImage != null)
                {
                    productImage.IsActive = isActive;
                    productImage.DeletedAt = isActive ? null : DateTime.Now;

                    await _context.SaveChangesAsync();

                    var fileResult = _fileHelper.DeleteFile(_webHostEnvironment, "product-images/" + productImage.Image);

                    resultModel = _resultModelHelper.CreateResultModel(isActive ? ResultModelEnum.Product_Image_Restore_Delete.ToString() : ResultModelEnum.Product_Image_Deleted.ToString(), isActive ? (int)ResultModelEnum.Product_Image_Restore_Delete : (int)ResultModelEnum.Product_Image_Deleted, isActive ? productImage : null);
                }

                else
                {
                    resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Product_Image_Not_Found.ToString(), (int)ResultModelEnum.Product_Image_Not_Found);
                }
            }

            else
            {
                resultModel = _resultModelHelper.CreateResultModel(ResultModelEnum.Transaction_Error.ToString(), (int)ResultModelEnum.Transaction_Error);
            }

            return resultModel;
        }

        [HttpPost]
        public async Task<ResultModel> MakeBannerPhotoToSelectedPhoto(int id, int productId)
        {
            ResultModel resultModel = new ResultModel();

            if (id > 0 && productId > 0)
            {
                var lastBannerPhoto = await _context.ProductImages.FirstOrDefaultAsync(x => x.ProductId == productId && x.IsBanner);

                if (lastBannerPhoto != null)
                {

                    lastBannerPhoto.IsBanner = false;

                    await _context.SaveChangesAsync();
                    var productPhoto = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == id);

                    if (productPhoto != null)
                    {
                        productPhoto.IsBanner = true;
                        await _context.SaveChangesAsync();

                        resultModel.Code = (int)ResultModelEnum.Product_Image_Updated;
                        resultModel.Message = ResultModelEnum.Product_Image_Updated.ToString();
                    }
                }

                else
                {
                    var productPhoto = await _context.ProductImages.FirstOrDefaultAsync(x => x.Id == id);

                    if (productPhoto != null)
                    {
                        productPhoto.IsBanner = true;
                        await _context.SaveChangesAsync();

                        resultModel.Code = (int)ResultModelEnum.Product_Image_Updated;
                        resultModel.Message = ResultModelEnum.Product_Image_Updated.ToString();
                    }
                }
            }

            else
            {
                resultModel.Code = (int)ResultModelEnum.Transaction_Error;
                resultModel.Message = ResultModelEnum.Transaction_Error.ToString();
            }

            return resultModel;
        }
    }
}
