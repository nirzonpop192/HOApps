using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.UWP.Services;
using SQLite.Net;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(UWPSQLiteStorage))]
namespace HO.Apps.UWP.Services
{
    public class UWPSQLiteStorage : ISQLiteStorage
    {
        private readonly ICrossFileService CrossFileService;
        public UWPSQLiteStorage()
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
            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}
