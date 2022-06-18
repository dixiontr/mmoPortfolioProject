using mmo.Domain.Common;

namespace mmo.Application.Exceptions
{
    public abstract class aCustomException
    {
        public string tr_TR { get; set; }
        public string en_US { get; set; }
        public string entityTR { get; set; }
        public string entityEN { get; set; }

        public aCustomException()
        {
            
        }
        public aCustomException(Type T)
        {
            LanguageAttribute languageAttribute =
                (LanguageAttribute) Attribute.GetCustomAttribute(T, typeof(LanguageAttribute));

            if (languageAttribute != null)
            {
                entityTR = languageAttribute.tr_TR;
                entityEN = languageAttribute.en_US;
            }
        }
        
        public string GetMessage(string culture)
        {
            culture = culture.Replace("-", "_");
            return GetType().GetProperty(culture).GetValue(this,null).ToString();
        }
    }
}