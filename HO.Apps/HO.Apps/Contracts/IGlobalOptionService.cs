using HO.Apps.Models;
using System.Collections.Generic;

namespace HO.Apps.Contracts
{
    public interface IGlobalOptionService
    {
        List<GlobalOption> GetOptions();
        GlobalOption GetOption(string key);
        string GetOptionContent(string key);
        void SetOption(GlobalOption option);
        void SetOption(string key, string value);
        void EnsureGlobalOptionExists(string key, string value);
    }
}
