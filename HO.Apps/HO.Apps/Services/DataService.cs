using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Helpers;
using HO.Apps.Models;
using HO.Apps.Services;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataService))]
namespace HO.Apps.Services
{
    public class DataService : IDataService
    {
        private readonly ICrossFileService _crossFileService;
        public DataService()
        {
            _crossFileService = DependencyService.Get<ICrossFileService>();
        }
        public void CreateDatabase()
        {
            SQLiteClientBase<GlobalOption> globalOption = new SQLiteClientBase<GlobalOption>();
            SQLiteClientBase<Sponsor> sponsor = new SQLiteClientBase<Sponsor>();
            SQLiteClientBase<LanguagePack> languagePack = new SQLiteClientBase<LanguagePack>();
            SQLiteClientBase<LanguageResource> languageResource = new SQLiteClientBase<LanguageResource>();
            SQLiteClientBase<UserOption> userOption = new SQLiteClientBase<UserOption>();
            SQLiteClientBase<milkDigitalID> milkDigitalId = new SQLiteClientBase<milkDigitalID>();
        }

        public void CreateDataDirectoryStructure()
        {
            string basePath = _crossFileService.GetDefaultDirectory();
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.DatabaseDirectory));
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.DocumentsDirectory));
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.ImportDirectory));
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.LibraryDirectory));
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.OpenDocuemntsDirectory));
            _crossFileService.CreateDirectory(Path.Combine(basePath, ApplicationSettingsConstant.TempDirectory));
        }
    }
}
