using Android.OS;
using HO.Apps.Contracts;
using HO.Apps.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationService))]
namespace HO.Apps.Droid.Services
{
    public class ApplicationService : IApplicationService
    {
        public void Terminate()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}