using HO.Apps.Models;

namespace HO.Apps.Contracts
{
    public interface ILanguagePackService
    {
        LanguagePack GetLanguagePack(string languageCode, string stringKey);
        void SetLanguagePack(LanguagePack languagePack);
    }
}
