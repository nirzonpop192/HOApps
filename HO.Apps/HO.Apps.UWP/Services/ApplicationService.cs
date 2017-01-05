using HO.Apps.Contracts;
using HO.Apps.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationService))]
namespace HO.Apps.UWP.Services
{
    public class ApplicationService : IApplicationService
    {
        public void Terminate()
        {
            Windows.UI.Xaml.Application.Current.Exit();
        }
    }
}