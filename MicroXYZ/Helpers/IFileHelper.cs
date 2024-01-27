using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MicroXYZ.Models;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public interface IFileHelper
    {
        public Task<ResultModel> SaveFiles(IWebHostEnvironment _webHostEnvironment, IFormFile formFile, string whichFolder, string whichUnderFolder = null);

        public ResultModel DeleteFile(IWebHostEnvironment _webHostEnvironment, string fileUrl = "");
    }
}
