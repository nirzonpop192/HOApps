using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.iOS.Services;
using SQLite.Net;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSSQLiteStorage))]
namespace HO.Apps.iOS.Services
{
    public class iOSSQLiteStorage : ISQLiteStorage
    {
        private readonly ICrossFileService CrossFileService;
        public iOSSQLiteStorage()
        {
            CrossFileService = DependencyService.Get<ICrossFileService>();
        }
        public SQLiteConnection GetConnection()
        {
            string databaseDirectory = Path.Combine(CrossFileService.GetDefaultDirectory(),
              ApplicationSettingsConstant.DatabaseDirectory);

            databaseDirectory = CrossFileService.CreateDirectory(databaseDirectory);

            string path = Path.Combine(databaseDirectory, ApplicationSettingsConstant.DatabaseName);

            Debug.WriteLine("Database path: " + path);

            // Create the Connection
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}
