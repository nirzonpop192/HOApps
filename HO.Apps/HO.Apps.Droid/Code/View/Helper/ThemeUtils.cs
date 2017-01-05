
using Android.App;
using Android.OS;
using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Droid;
using HO.Apps.Models;
using Xamarin.Forms;

namespace Home_Organizer.Code.View.Helper
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.hello);

            // Create your application here
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            var path = DependencyService.Get<ICrossFileService>().GetDefaultDirectory();
            var globalOptionTable = new SQLiteClientBase<GlobalOption>();
        }
    }
}