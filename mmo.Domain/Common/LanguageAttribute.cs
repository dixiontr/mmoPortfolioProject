namespace mmo.Domain.Common
{

    public class LanguageAttribute: Attribute
    {
        public string tr_TR;
        public string en_US;
        public LanguageAttribute(string tr_TR, string en_US)
        {
            this.tr_TR = tr_TR;
            this.en_US = en_US;
        }
        
    }

}