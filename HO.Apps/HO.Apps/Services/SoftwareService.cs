using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Messaging;
using HO.Apps.Models;
using HO.Apps.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SoftwareService))]
namespace HO.Apps.Services
{
    public class SoftwareService : ISoftwareService
    {
        public SplashDefinition AgentSplashDefData(string registrationId, string promoCode)
        {
            var result = default(SplashDefinition);
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.AgentSplashDefDataUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<SplashDefinition>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string GetAgentSplash(string registrationId, string promoCode)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.AgentSplashUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string GetImageId(string registrationId, string promoCode)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.ImageIdUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string GetMessageText(string registrationId, string promoCode)
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.MessageTextUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string[] GetSponsorIds(string registrationId, string promoCode)
        {
            string[] result = new string[] { };
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.GetSponsorIdsUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string[]>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public SponsorZip GetSponsorZipFiles(string registrationId, string promoCode)
        {
            var result = new SponsorZip();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.SponsorZipFilesUrl}/{registrationId}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<SponsorZip>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string HO_3_0_0()
        {
            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.HO3VersionUrl}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public string HO_4_0_0()
        {

            var result = string.Empty;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.HO4VersionUrl}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<string>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public ImageResponse IsRegistrationKeyValid(string registrationID, string promoCode)
        {
            var result = new ImageResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.RegistrationdKeyUrl}/{registrationID}/{promoCode}");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<ImageResponse>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public bool IsValidPromoCode(string promoCode)
        {
            var result = false;
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.IsPromoCodeValidUrl}/{ promoCode }");
                    var json = client.GetStringAsync(url).Result;
                    result = JsonConvert.DeserializeObject<bool>(json);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public RegistrationResponse MemberRegistration(RegistrationRequest request)
        {
            var result = new RegistrationResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    var url = new Uri($"{ ServiceUrl.GetUrl() }{ServiceUrl.MemberRegistrationUrl}");
                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content);
                    var r = response.Result.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RegistrationResponse>(r);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
