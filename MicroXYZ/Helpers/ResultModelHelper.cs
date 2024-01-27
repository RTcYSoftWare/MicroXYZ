using MicroXYZ.Models;

namespace MicroXYZ.Helpers
{
    public class ResultModelHelper : IResultModelHelper
    {
        public ResultModel CreateResultModel(string message, int code, object data = null)
        {
            ResultModel resultModel = new ResultModel();

            resultModel.Message = message;
            resultModel.Code = code;
            resultModel.Data = data;

            return resultModel;
        }
    }
}
