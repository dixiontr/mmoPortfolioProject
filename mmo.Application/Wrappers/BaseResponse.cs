using System.Net;

namespace mmo.Application.Wrappers
{
    
    public class BaseResponse : BaseResponse<object>
    {
        
    }
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

}