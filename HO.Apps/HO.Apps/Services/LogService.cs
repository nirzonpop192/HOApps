using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Services;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogService))]
namespace HO.Apps.Services
{
    public class LogService : ILogService
    {
        private readonly ICrossFileService _crossFileService;
        private string _logDirectory;
        public LogService()
        {
            _crossFileService = DependencyService.Get<ICrossFileService>();
            _logDirectory = Path.Combine(_crossFileService.GetDefaultDirectory(),
                            ApplicationSettingsConstant.LogDirectory);

            _logDirectory = _crossFileService.CreateDirectory(_logDirectory);

        }

        public void Log(string content, string fileName = "")
        {
            content = $"{DateTime.Now.ToString(SettingConstant.DefaultDateTimeFormat)}{SettingConstant.TabSeparator}{content}{Environment.NewLine}";

            if (fileName.IsEmpty())
                _crossFileService.Save(content, Path.Combine(_logDirectory, Extensions.GenerateErrorFileName()));
            else
                _crossFileService.Save(content, Path.Combine(_logDirectory, fileName));
        }

        public void LogException(Exception ex)
        {
            _crossFileService.Save(ex.Message, Path.Combine(_logDirectory, Extensions.GenerateErrorFileName()));
        }
    }
}
