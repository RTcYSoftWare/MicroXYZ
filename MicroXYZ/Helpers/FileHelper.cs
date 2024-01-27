using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MicroXYZ.Enums;
using MicroXYZ.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public class FileHelper : IFileHelper
    {
        public async Task<ResultModel> SaveFiles(IWebHostEnvironment _webHostEnvironment, IFormFile formFile, string whichFolder, string whichUnderFolder = null)
        {
            ResultModel resultModel = new ResultModel();

            string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, whichFolder);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (formFile != null)
            {
                string uniqFileName = "";

                try
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

                    uniqFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

                    string filePath = Path.Combine(uploadsFolder, uniqFileName);
                    await formFile.CopyToAsync(new FileStream(filePath, FileMode.Create));

                    resultModel.Code = (int)ResultModelEnum.IForm_File_Saved;
                    resultModel.Message = ResultModelEnum.IForm_File_Saved.ToString();
                    resultModel.Data = uniqFileName;
                }
                catch (Exception e)
                {                    
                    resultModel.Code = (int)ResultModelEnum.IForm_File_Error;
                    resultModel.Message = ResultModelEnum.IForm_File_Error.ToString();
                }
            }

            else
            {                
                resultModel.Code = (int)ResultModelEnum.IForm_File_Is_Null;
                resultModel.Message = ResultModelEnum.IForm_File_Is_Null.ToString();
            }

            return resultModel;
        }

        public ResultModel DeleteFile(IWebHostEnvironment _webHostEnvironment,string fileUrl = "")
        {
            ResultModel resultModel = new ResultModel();
           
            if (File.Exists(Path.Combine(_webHostEnvironment.WebRootPath, fileUrl)))
            {
                try
                {
                    File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, fileUrl));

                    resultModel.Code = (int)ResultModelEnum.IForm_File_Deleted;
                    resultModel.Message = ResultModelEnum.IForm_File_Deleted.ToString();                    
                }
                catch (Exception e)
                {
                    resultModel.Code = (int)ResultModelEnum.IForm_File_Error;
                    resultModel.Message = ResultModelEnum.IForm_File_Error.ToString();
                }
            }
            else
            {
                resultModel.Code = (int)ResultModelEnum.IForm_File_Not_Found;
                resultModel.Message = ResultModelEnum.IForm_File_Not_Found.ToString();
            }

            return resultModel;
        }
    }
}
