using HO.Apps.Contracts;
using HO.Apps.Droid.Services;
using HO.Apps.Helpers;
using SQLite.Net;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSQLiteStorage))]
namespace HO.Apps.Droid.Services
{
    public class AndroidSQLiteStorage : ISQLiteStorage
    {
        private readonly ICrossFileService CrossFileService;
        public AndroidSQLiteStorage()
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
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}