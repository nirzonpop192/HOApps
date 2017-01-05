using HO.Apps.Contracts;
using HO.Apps.Data;
using HO.Apps.Helpers;
using HO.Apps.Models;
using HO.Apps.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

[assembly: Dependency(typeof(SponsorService))]
namespace HO.Apps.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly SQLiteClientBase<Sponsor> _sponsorContext;
        private readonly ICrossFileService _crossFileService;
        private readonly IGlobalOptionService _globalOptionService;
        private readonly ILogService _logService;

        public SponsorService()
        {
            _sponsorContext = new SQLiteClientBase<Sponsor>();
            _crossFileService = DependencyService.Get<ICrossFileService>();
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _logService = DependencyService.Get<ILogService>();
        }
        public Sponsor GetSponsor(int id)
        {
            return _sponsorContext.Get(id);
        }

        public List<Sponsor> GetSponsors()
        {
            return _sponsorContext.All().ToList();
        }

        public void SaveSponsor(SponsorZip sponsorZip)
        {
            Queue<Guid> keys = new Queue<Guid>();

            keys.Enqueue(new Guid("61c98633-6a56-4e6c-b778-67ca9c2fd788"));
            keys.Enqueue(new Guid("5dcf147e-ca79-46e6-b0bc-56f72712bbcc"));
            keys.Enqueue(new Guid("3a4c4e4c-a8e7-42a5-b443-bf7ce06b4dc9"));
            keys.Enqueue(new Guid("8a4fc4db-32ad-43e0-9c4f-a53a723556e1"));
            keys.Enqueue(new Guid("8868a907-81fd-4fbe-b6ba-bd41aec38113"));
            keys.Enqueue(new Guid("98ef9d9e-010b-4c42-a9b4-0af1400fadf2"));
            keys.Enqueue(new Guid("59cddf7c-8f63-46d2-8c39-2b76b0e929ef"));
            keys.Enqueue(new Guid("f33afe4b-dea7-41c4-86da-307f108eae90"));
            keys.Enqueue(new Guid("ff7f8731-427f-4d3f-b9cb-c7e1eee07576"));

            List<Sponsor> result = new List<Sponsor>();
            if (sponsorZip == null || sponsorZip.ZipFile.IsEmpty())
            {

            }
            else
            {

            }

            string fileName = ApplicationSettingsConstant.SponsorFileName;
            string path = Path.Combine(_crossFileService.GetDefaultDirectory(),
                ApplicationSettingsConstant.DocumentsDirectory,
                fileName);
            if (!_crossFileService.IsFileExists(path))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(SettingConstant.milkDigitalID);
                sb.AppendLine(SettingConstant.SilverDigitalID);
                sb.AppendLine(SettingConstant.EarsWebSite);
                _crossFileService.Save(sb.ToString(), path);
            }

            string content = _crossFileService.Load(path);
            string[] sponsorEntries = Regex.Split(content, Environment.NewLine);
            foreach (string sponsorEntry in sponsorEntries)
            {
                string[] sponsorAttributes = sponsorEntry.Split(',');
                if (sponsorAttributes.Length == 3)
                {
                    Sponsor sponsor = new Sponsor();
                    if (sponsorAttributes[1].Contains("Club"))
                        sponsor.SponsorKey = Guid.Empty;
                    else
                        sponsor.SponsorKey = keys.Dequeue();

                    sponsor.SponsorIcon = sponsorAttributes[0].ConvertToBase64String();
                    sponsor.SponsorName = sponsorAttributes[1].Trim();
                    sponsor.SponsorUrl = sponsorAttributes[2].Trim();

                    result.Add(sponsor);
                }
            }

            // Store Sponsor List to database if needed


            // Store the new sponsor id and list for re-use.....Andy 
            string sponsorList = JsonConvert.SerializeObject(result);
            _globalOptionService.SetOption(SettingConstant.SponsorListKey, sponsorList);
            string sponsorId = sponsorZip == null ?
                _globalOptionService.GetOptionContent(SettingConstant.SponsorIdKey)
                : sponsorZip.ZipId.ToString();

            _globalOptionService.SetOption(SettingConstant.SponsorIdKey, sponsorId);
        }

        public void SaveSponsor(Sponsor sponsor)
        {
            _sponsorContext.Save(sponsor);
        }

        public List<Sponsor> GetDownloadedSponsors()
        {
            // Just use the previously downloaded list
            List<Sponsor> sponsors = new List<Sponsor>();
            try
            {
                string result = _globalOptionService.GetOptionContent(SettingConstant.SponsorListKey);
                if (!result.IsEmpty())
                    sponsors = JsonConvert.DeserializeObject<List<Sponsor>>(result);
            }
            catch (Exception ex)
            {
                _logService.LogException(ex);
            }

            return sponsors;
        }
    }
}
