namespace mmo.Application.Exceptions.CustomExceptions
{

    public class UnhandledException : aCustomException
    {
        public UnhandledException()
        {
            tr_TR = "Beklenmeyen bir hata oluştu";
            en_US = "An unexpected error occured";
        }
    }

}