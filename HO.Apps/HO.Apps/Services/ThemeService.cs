using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Models;
using HO.Apps.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(ThemeService))]
namespace HO.Apps.Services
{
    public class ThemeService : IThemeService
    {
        private readonly IGlobalOptionService _globalOptionService;
        public ThemeService()
        {
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
        }
        public void CreateThemes()
        {

        }

        public string GetTheme(string name)
        {
            string themeName = $"{ApplicationSettingsConstant.ThemePrefix}{name}";
            return GetThemes()
                .FirstOrDefault(t => t == themeName);
        }

        public List<string> GetThemes()
        {
            List<string> result = new List<string>();

            var themes = _globalOptionService.GetOptions()
                            .Where(o => o.OptionKey.StartsWith(ApplicationSettingsConstant.ThemePrefix))
                            .ToList();
            if (themes.Count > 0)
            {
                result.AddRange(themes.Select(t => t.OptionValue));
            }

            return result;
        }

        public void SetTheme(string name)
        {
            string themeName = $"{ApplicationSettingsConstant.ThemePrefix}{name}";
            _globalOptionService.SetOption(new GlobalOption { OptionKey = themeName, OptionValue = name });
        }
    }
}
