using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Messaging;
using HO.Apps.Models;
using Plugin.Connectivity;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace HO.Apps.Pages
{
    public partial class TestPage : ContentPage
    {
        private readonly ISoftwareService _SoftwareService;
        private readonly ICrossFileService _CrossFileService;
        private readonly ImilkDigitalIDService _digitalIDService;
        public TestPage()
        {
            InitializeComponent();
            _SoftwareService = DependencyService.Get<ISoftwareService>();
            _CrossFileService = DependencyService.Get<ICrossFileService>();
            _digitalIDService = DependencyService.Get<ImilkDigitalIDService>();

            string promoCode = "106-19522-1";
            string registrationId = "32-AMKM5";

            // Check Cross Connectivity
            if (CrossConnectivity.Current.IsConnected)
            {
                var bandwidths = CrossConnectivity.Current.Bandwidths;
                var connectionTypes = CrossConnectivity.Current.ConnectionTypes;

                // Check Cross Settings
                if (Settings.GeneralSettings.IsEmpty())
                    Settings.GeneralSettings = promoCode;

                string generalSettings = Settings.GeneralSettings;

                // Check Service
                // var result = _SoftwareService.AgentSplashDefData(registrationId, promoCode);

                string path = _CrossFileService.GetDefaultDirectory();
                Debug.WriteLine(path);
                //result = _SoftwareService.GetAgentSplash(registrationId, promoCode);
                //ImageName.Source = ImageSource.FromUri(new Uri(result));

                //result = _SoftwareService.GetImageId(registrationId, promoCode);
                //result = _SoftwareService.GetMessageText(registrationId, promoCode);
                //var files = _SoftwareService.GetSponsorZipFiles(registrationId, promoCode);

                //string ho3version = _SoftwareService.HO_3_0_0();
                //string ho4version = _SoftwareService.HO_4_0_0();
                //ImageResponse response = _SoftwareService.IsRegistrationKeyValid(registrationId, promoCode);

                RegistrationRequest request = new RegistrationRequest()
                {
                    DevLicenseKey = "",
                    DevUserKey = "",
                    EmailAddress = "msmsfarmers279@bdweb.biz",
                    FirstName = "msmsfarmers279",
                    LastName = "msmsfarmers279",
                    Password = "password",
                    PasswordAnswer = "Yes",
                    PasswordQuestion = "Is it common?",
                    PreferredLanguage = 12,
                    PromoCode = "106-22222-2",
                    SubscribeToEarsNotification = true,
                    SubscribeToMilkNotification = true,
                    Username = "msmsfarmers279",
                    ZipCode = "74110"
                };

                //RegistrationResponse resonse = _SoftwareService.MemberRegistration(request);
                //string path = _CrossFileService.CreateDirectory("Digital ID");
                //string fileName = "Log.txt";
                //if (_CrossFileService.IsFileExists(fileName, path))
                //{
                //    _CrossFileService.DeleteFile(fileName, path);
                //}
                //else
                //{
                //    // Add File Content
                //    string content = $"{DateTime.Now.ToString("dd MMM yyy hh:mm:ss")}\tApplication Started.{Environment.NewLine}";
                //    _CrossFileService.Save(fileName, content, path);

                //    content = $"{DateTime.Now.ToString("dd MMM yyy hh:mm:ss")}\tFile And Directory are Created.{Environment.NewLine}";
                //    _CrossFileService.Save(fileName, content, path);

                //    content = $"{DateTime.Now.ToString("dd MMM yyy hh:mm:ss")}\tContent is going to be loaded.{Environment.NewLine}";
                //    _CrossFileService.Save(fileName, content, path);


                //    // Read File Content
                //    LabelMessage.Text = _CrossFileService.Load(fileName, path);
                //}



            }
            else
            {
                DisplayAlert("Network Info", "You're not connected to internet", "Ok");
            }


            // Save To Database
            milkDigitalID digitalId = new milkDigitalID()
            {
                FirstName = "Jamal",
                LastName = "Uddin",
                MiddleName = "MiddleName",
                NickName = "Nick Name",
                DateOfBirth = DateTime.Now,
                Gender = "Male",
                Height = "4",
                Weight = "10",
                Age = 15,
                BloodType = "Blood Type",
                Comments = "Comments",
                Contact = "Contact",
                DistinguishingMarks = "Dis",
                EyeColor = "Eye Color",
                Glasses = "Glasses",
                HairColor = "Hair Color",
                Race = "Race",
                PhotoDate = DateTime.UtcNow,
                PortraitView = null,
                ImagePortraitView = "",
                SideView = null,
                ImageSideView = ""
            };

            //  _digitalIDService.CreateDigitalID(digitalId);

            var ids = _SoftwareService.GetSponsorIds(registrationId, promoCode);

            string test1 = @"D:\farmersImg\e3be5524-b6eb-4ead-ba11-d381e74474ac.jpg".ConvertToImageUrl();

            ImageName.Source = test1.FromBase64String();

        }
    }
}
