using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IThemeService
    {
        void CreateThemes();
        List<string> GetThemes();
        string GetTheme(string name);
        void SetTheme(string name);
    }
}
