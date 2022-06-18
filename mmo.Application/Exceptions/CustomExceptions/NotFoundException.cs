using System.Text.Json;
using mmo.Domain.Common;

namespace mmo.Application.Exceptions.CustomExceptions
{
    public class NotFoundException : aCustomException
    {
        public NotFoundException(Type T) : base(T)
        {
            tr_TR = entityTR + " Bulunamadı";
            en_US = entityEN + " is not Found";
        }
    }
}