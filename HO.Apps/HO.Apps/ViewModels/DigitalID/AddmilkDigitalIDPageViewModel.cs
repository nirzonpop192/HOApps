using HO.Apps.Contracts;
using HO.Apps.Controls.Pages;
using HO.Apps.Helpers;
using HO.Apps.Models;
using HO.Apps.Pages.DigitalID;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.DigitalID
{
    public class AddmilkDigitalIDPageViewModel : BaseViewModel
    {
        private readonly ICrossMediaService _crossMediaService;
        private HOPage Root;
        Command _gotoNextStep { get; set; }
        Command _frontCameraComamnd;
        Command _sideCameraCommand;
        Command _homeCommand;

        public AddmilkDigitalIDPageViewModel(INavigation navigation = null, HOPage root = null)
        : base(navigation)
        {
            _crossMediaService = DependencyService.Get<ICrossMediaService>();
            Root = root;
#if DEBUG
            FirstStep = new FirstStepModel
            {
                FirstName = "First Name",
                MiddleName = "Middle Name",
                LastName = "Last Name",
                NickName = "Nick Name",
                DateOfBirth = new DateTime(1990, 1, 1),
                Gender = "Male",
                Height = "5",
                Weight = "50"
            };
#endif
        }

        public List<string> Gender
        {
            get
            {
                return new List<string>
                {
                    "Male", "Female"
                };
            }
        }


        public FirstStepModel FirstStep { get; set; }


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
        public Command SideCameraCommand
        {
            get
            {
                return _sideCameraCommand ??
                    (_sideCameraCommand = new Command(async () => await ExecuteSideCameraCommand()));
            }
        }


        private async Task ExecuteSideCameraCommand()
        {
            var response = await _crossMediaService.TakePhotoAsync();
            if (response.IsSuccess)
                FirstStep.SidePhoto = response;
        }

        public Command FrontCameraCommand
        {
            get
            {
                return _frontCameraComamnd ??
                  (_frontCameraComamnd = new Command(async () => await ExecuteFrontCameraCommand()));
            }
        }

        private async Task ExecuteFrontCameraCommand()
        {
            var response = await _crossMediaService.TakePhotoAsync();
            if (response.IsSuccess)
                FirstStep.FrontPhoto = response;
        }

        public Command GotoNextStep
        {
            get
            {
                return _gotoNextStep ??
                  (_gotoNextStep = new Command(ExecuteGotoNextStep));
            }
        }

        private async void ExecuteGotoNextStep(object obj)
        {
            // Check for validation
            if (!CheckInputs())
            {
                IsValid = false;
                return;
            }

            IsValid = true;
            await PushAsync(new AddmilkDigitalIDFinalStepPage(FirstStep));
        }

        private bool CheckInputs()
        {
            bool result = true;
            Message = string.Empty;
            if (FirstStep.FirstName.IsEmpty())
            {
                Message += $"First Name is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FirstStep.LastName.IsEmpty())
            {
                Message += $"Last Name is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FirstStep.MiddleName.IsEmpty())
            {
                Message += $"Middle Name is Missing!{Environment.NewLine}";
                result = false;
            }
            if (FirstStep.NickName.IsEmpty())
            {
                Message += $"Nick Name is Missing!{Environment.NewLine}";
                result = false;
            }

            if (FirstStep.Height.IsEmpty())
            {
                Message += $"Height is Missing!{Environment.NewLine}";
                result = false;
            }

            if (FirstStep.Height.IsEmpty())
            {
                Message += $"Weight is missing!{Environment.NewLine}";
                result = false;
            }

            return result;
        }
    }
}
