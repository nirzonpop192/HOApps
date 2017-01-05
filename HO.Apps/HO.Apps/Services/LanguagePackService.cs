using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Models;

namespace HO.Apps.Services
{
    public class LanguagePackService : ILanguagePackService
    {
        private readonly SQLiteClientBase<LanguagePack> _languageContext;
        public LanguagePackService()
        {
            _languageContext = new SQLiteClientBase<LanguagePack>();
        }
        public LanguagePack GetLanguagePack(string languageKey, string stringKey)
        {
            return null;
        }

        public void SetLanguagePack(LanguagePack languagePack)
        {
            _languageContext.Save(languagePack);
        }
    }
}
