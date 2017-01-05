using HO.Apps.Contracts;
using HO.Apps.iOS.Services;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationService))]
namespace HO.Apps.iOS.Services
{
    public class ApplicationService : IApplicationService
    {
        public void Terminate()
        {
            Thread.CurrentThread.Abort();
        }
    }
}