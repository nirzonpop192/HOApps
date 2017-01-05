using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Models;
using HO.Apps.Services;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(GlobalOptionService))]
namespace HO.Apps.Services
{
    public class GlobalOptionService : IGlobalOptionService
    {
        private readonly SQLiteClientBase<GlobalOption> _optionContext;
        public GlobalOptionService()
        {
            _optionContext = new SQLiteClientBase<GlobalOption>();
        }

        public List<GlobalOption> GetOptions()
        {
            return _optionContext
                .All()
                .ToList();
        }
        public GlobalOption GetOption(string key)
        {
            return _optionContext.All()
                .Where(o => o.OptionKey == key)
                .FirstOrDefault();
        }

        public string GetOptionContent(string key)
        {
            var result = string.Empty;
            var option = _optionContext.All()
                .Where(o => o.OptionKey == key)
                .FirstOrDefault();
            if (option != null)
                result = option.OptionValue;

            return result;
        }

        public void SetOption(GlobalOption option)
        {
            var selectedOption = GetOption(option.OptionKey);
            if (selectedOption == null)
            {
                _optionContext.Save(option);
            }
            else
            {
                selectedOption.OptionValue = option.OptionValue;
                _optionContext.Update(selectedOption);
            }
        }

        public void SetOption(string key, string value)
        {
            var selectedOption = GetOption(key);
            if (selectedOption == null)
            {
                GlobalOption option = new GlobalOption
                {
                    OptionKey = key,
                    OptionValue = value
                };
                _optionContext.Save(option);
            }
            else
            {
                selectedOption.OptionValue = value;
                _optionContext.Update(selectedOption);
            }
        }

        public void EnsureGlobalOptionExists(string key, string value)
        {
            if (GetOption(key) == null)
                SetOption(new GlobalOption { OptionKey = key, OptionValue = value });
        }
    }
}
