using HO.Apps.Localization;
using HO.Apps.UWP.Localization;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace HO.Apps.UWP.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return new CultureInfo(CultureInfo.CurrentCulture.Name);
        }
    }
}
