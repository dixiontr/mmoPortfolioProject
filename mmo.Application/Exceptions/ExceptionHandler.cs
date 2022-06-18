using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using mmo.Application.Wrappers;

namespace mmo.Application.Exceptions
{
    public static class ExceptionHandler
    {
        public static BaseResponse HandleException(aCustomException exception)
        {
            var culture = CultureInfo.CurrentCulture.Name;
            Console.WriteLine(culture);
            BaseResponse response = new BaseResponse();
            response.Success = false;
            response.Message = exception.GetMessage(culture);

            return response;
        }
        public static BaseResponse HandleException(aCustomException exception, string culture)
        {
            BaseResponse response = new BaseResponse();
            response.Success = false;
            response.Message = exception.GetMessage(culture);

            return response;
        }
        
        
    }
}