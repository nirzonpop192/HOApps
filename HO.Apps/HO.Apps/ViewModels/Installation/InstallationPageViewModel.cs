using HO.Apps.Contracts;
using HO.Apps.Helpers;
using HO.Apps.Messaging;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HO.Apps.ViewModels.Installation
{
    public class InstallationPageViewModel : BaseViewModel
    {
        private readonly IGlobalOptionService _globalOptionService;
        private readonly IApplicationService _applicationService;
        private readonly IPromoService _promoService;
        private readonly ILogService _logService;
        public InstallationPageViewModel(INavigation navigation = null)
            : base(navigation)
        {
            _globalOptionService = DependencyService.Get<IGlobalOptionService>();
            _applicationService = DependencyService.Get<IApplicationService>();
            _promoService = DependencyService.Get<IPromoService>();
            _logService = DependencyService.Get<ILogService>();
            PromoCode = ShowPromoCode();

#if DEBUG
            FirstName = "Naimul";
            LastName = "Huq";
            Email = "naimul.huq.125@milkdigitalid.com";
            UserName = "naimul.huq.125";
            PostalCode = "74110";
            Password = "password";
            ConfirmPassword = "password";
            SecretAnswer = "secret";
            RegistrationId = "4895-6I0ZY";
#endif
        }

        private string ShowPromoCode()
        {
            string result = string.Empty;
            var option = _globalOptionService.GetOption(SettingConstant.PromoCodeKey);
            if (option != null)
                result = option.OptionValue;

            return result;
        }

        Command _completeSetupCommand;
        Command _closeCommand;
        Command _registerCommand;
        public List<string> SecretQuestions
        {
            get
            {
                return new List<string>()
                {
                    "What was the name of your first pet?",
                    "What is your mother's maiden name?",
                    "In what city were you born?"
                };
            }
        }

        public List<string> LanguagePreferences
        {
            get
            {
                return new List<string>()
                {
                    "English",
                    "Espanol"
                };
            }
        }
        public string RegistrationId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string SelectedSecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string PostalCode { get; set; }
        public string SelectedLanguagePreference { get; set; }
        public bool SubscribeTomilkNotification { get; set; }
        public bool SubscribeToEARSNotification { get; set; }

        public Command CloseCommand
        {
            get
            {
                return _closeCommand ??
                    (_closeCommand = new Command(ExecuteCloseCommand));
            }
        }

        private void ExecuteCloseCommand(object obj)
        {
            _applicationService.Terminate();
        }

        public Command CompleteSetupCommand
        {
            get
            {
                return _completeSetupCommand ??
                    (_completeSetupCommand = new Command(ExecuteCompleteSetupCommand));
            }
        }

        public Command RegisterCommand
        {
            get
            {
                return _registerCommand ??
                  (_registerCommand = new Command(ExecuteRegisterCommand));
            }
        }

        private void ExecuteRegisterCommand(object obj)
        {
            try
            {
                if (RegistrationId.IsEmpty()
                    || !_promoService.IsRegistrationIdValid(RegistrationId))
                {

                    Message = "Invalid Registration Code\nPlease try again";
                    IsValid = false;
                    return;
                }
                else // box is not empty so validate the text
                {
                    Message = string.Empty;
                    IsValid = true;
                    GotoNextProcess();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = "Sorry, we are having trouble to communicate with Home Organizer Club Website!";
                _logService.LogException(ex);
                Application.Current.MainPage.DisplayAlert("Registration Failed!", errorMessage, "Ok");
            }
        }

        private void ExecuteCompleteSetupCommand(object obj)
        {
            try
            {
                // Check for validation
                if (!CheckInputs())
                {
                    IsValid = false;
                    return;
                }

                IsValid = true;

                RegistrationRequest request = new RegistrationRequest()
                {
                    EmailAddress = Email.ToLower(),
                    Username = UserName,
                    FirstName = FirstName.TrimEnd(),
                    LastName = LastName.TrimEnd(),
                    Password = Password,
                    PasswordAnswer = SecretAnswer,
                    PasswordQuestion = SelectedSecretQuestion,
                    ZipCode = PostalCode,
                    PreferredLanguage = SelectedLanguagePreference.IsEmpty() ? 1 : 2,
                    SubscribeToMilkNotification = SubscribeTomilkNotification,
                    SubscribeToEarsNotification = SubscribeToEARSNotification,
                    PromoCode = PromoCode
                };
                bool result = _promoService.RegisterMember(request);
                if (result)
                {
                    GotoNextProcess();
                }
                else
                {
                    IsValid = false;
                    Message = "An error occured.";
                }
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Registration Failed!", ex.Message, "Ok");
            }
        }

        private void GotoNextProcess()
        {
            // check for OEM reminder


            // check for setup file on the desktop and Twain

            // Load Theme

            // Goto Main
            App.GoToRoot();
        }

        private bool CheckInputs()
        {
            bool result = true;
            Message = string.Empty;
            if (FirstName.IsEmpty())
            {
                Message += $"First Name is Missing!{Environment.NewLine}";
                result = false;
            }
            if (LastName.IsEmpty())
            {
                Message += $"Last Name is Missing!{Environment.NewLine}";
                result = false;
            }

            if (!Email.IsEmail())
            {
                Message += $"Invalid Email Address{Environment.NewLine}";
                result = false;

            }
            if (UserName.IsEmpty())
            {
                Message += $"Username is Missing!{Environment.NewLine}";
                result = false;
            }
            if (UserName.Length < 5)
            {
                Message += $"User name needs to be 6 letters or more{Environment.NewLine}";
                result = false;
            }

            if (!PostalCode.IsValidZipCode())
            {
                Message += $"Invalid US Zip code. Please enter 5 digits only{Environment.NewLine}";
                result = false;
            }

            if (SelectedSecretQuestion.IsEmpty())
            {
                Message += $"Please select a secret question.{Environment.NewLine}";
                result = false;
            }

            if (SecretAnswer.IsEmpty())
            {
                Message += $"Secrect answer is missing!{Environment.NewLine}";
                result = false;
            }

            if (Password.IsEmpty())
            {
                Message += $"Password is missing!{Environment.NewLine}";
                result = false;
            }

            if (!Password.Equals(ConfirmPassword, StringComparison.CurrentCulture))
            {
                Message += $"Passswords do not match!{Environment.NewLine}";
                result = false;
            }

            return result;
        }
    }
}
