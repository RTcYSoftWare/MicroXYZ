using MicroXYZ.Models;

namespace MicroXYZ.Helpers
{
    public interface IResultModelHelper
    {
        public ResultModel CreateResultModel(string message, int code, object data = null);
    }
}
