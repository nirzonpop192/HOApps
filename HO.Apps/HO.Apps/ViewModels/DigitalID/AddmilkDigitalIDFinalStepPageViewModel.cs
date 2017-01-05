using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Models;
using System;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.DigitalID
{
    public class AddmilkDigitalIDFinalStepPageViewModel : BaseViewModel
    {
        private readonly ImilkDigitalIDService _milkDigitalIDService;
        Command _savemilkDigitalIDCommand;
        Command _homeCommand;
        public AddmilkDigitalIDFinalStepPageViewModel(INavigation navigation = null, FirstStepModel firstStep = null)
            : base(navigation)
        {
            _milkDigitalIDService = DependencyService.Get<ImilkDigitalIDService>();
            FirstStep = firstStep;
            FinalStep = new FinalStepModel
            {
                CurrentAge = $"{CalculateYear()} Years",
                BloodType = "Blood Type",
                Comments = "Comments goes here",
                Contact = "0125856655",
                DistinguishingMarks = "No Symbol",
                EyeColor = "Normal",
                Glasses = "Glasses",
                HairColor = "Gray",
                Race = "Muslim"
            };
        }

        private double CalculateYear()
        {
            return (DateTime.UtcNow - FirstStep.DateOfBirth).Days / 365;
        }

        public FirstStepModel FirstStep { get; set; }
        public FinalStepModel FinalStep { get; set; }
        public Command SavemilkDigitalIDCommand
        {
            get
            {
                return _savemilkDigitalIDCommand ??
                    (_savemilkDigitalIDCommand = new Command(ExecuteSavemilkDigitalIDCommand));
            }
        }

        public Command HomeCommand
        {
            get
            {
                return _homeCommand ??
                  (_homeCommand = new Command(ExecuteHomeCommand));
            }

        }

        private void ExecuteHomeCommand(object obj)
        {
            // await Root.NavigateAsync(Models.Menus.MenuType.milkDigitalID);
            App.GoToRoot();
        }
        private void ExecuteSavemilkDigitalIDCommand()
        {
            // Check for validation
            if (!CheckInputs())
            {
                IsValid = false;
                return;
            }

            IsValid = true;

            // Save To Database
            milkDigitalID digitalId = new milkDigitalID()
            {
                FirstName = FirstStep.FirstName,
                LastName = FirstStep.LastName,
                MiddleName = FirstStep.MiddleName,
                NickName = FirstStep.NickName,
                DateOfBirth = FirstStep.DateOfBirth,
                Gender = FirstStep.Gender,
                Height = FirstStep.Height,
                Weight = FirstStep.Weight,
                Age = CalculateYear(),
                BloodType = FinalStep.BloodType,
                Comments = FinalStep.Comments,
                Contact = FinalStep.Contact,
                DistinguishingMarks = FinalStep.DistinguishingMarks,
                EyeColor = FinalStep.EyeColor,
                Glasses = FinalStep.Glasses,
                HairColor = FinalStep.HairColor,
                Race = FinalStep.Race,
                PhotoDate = DateTime.UtcNow,
            };

            if (FirstStep.FrontPhoto != null)
            {
                digitalId.PortraitView = ImageHelpers.ConvertStreamToBytes(FirstStep.FrontPhoto.Stream);
                digitalId.ImagePortraitView = FirstStep.FrontPhoto.Path;
            }

            if (FirstStep.SidePhoto != null)
            {
                digitalId.SideView = ImageHelpers.ConvertStreamToBytes(FirstStep.SidePhoto.Stream);
                digitalId.ImageSideView = FirstStep.SidePhoto.Path;
            }
            _milkDigitalIDService.CreateDigitalID(digitalId);
            App.GoToRoot();
            // App.CurrentApp.MainPage = new HOPage();

            // var result = await Application.Current.MainPage.DisplayAlert("Registration", "Successfully Registered!", "Ok", "Cancel");
        }

        private bool CheckInputs()
        {
            bool result = true;
            Message = string.Empty;
            if (FinalStep.EyeColor.IsEmpty())
            {
                Message += $"Eye Color is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FinalStep.HairColor.IsEmpty())
            {
                Message += $"Hair Color is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FinalStep.Contact.IsEmpty())
            {
                Message += $"Contact is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FinalStep.Race.IsEmpty())
            {
                Message += $"Race is Missing!{Environment.NewLine}";
                result = false;
            }

            return result;
        }
    }
}