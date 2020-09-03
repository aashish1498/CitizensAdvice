using System;
using CitizensAdvice.Models;
using CitizensAdvice.StaticClasses;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class AboutUsViewModel
    {
        public string AboutUsDetails { get; set; }
        public string CoronavirusText { get; set; }

        public ImageSource MyImageSource { get; set; }

        public Place Agency { get; }

        public Command CallNumberCommand { get; set; }
        public Command WebsiteLaunchCommand { get; set; }
        public Command SendEmailCommand { get; set; }
        public string CallText { get; set; }
        public string EmailText { get; set; }
        public string Website { get; set; }


        public AboutUsViewModel()
        {
            Agency = Database.DefaultPlace;

            AboutUsDetails =
                "Citizens Advice Redbridge (CAR) was set up in 1939 and has a long and successful history of" +
                " providing advice to the residents of Redbridge and campaigning on the issues that affect them." +
                " We share this mission with the Citizens Advice service, a national network of over 300 local advice agencies.";

            CoronavirusText =
                "During the coronavirus situation, to lower the risk to staff, volunteers and the people who come to us for help," +
                " we’ve closed our face to face services for the foreseeable future. We are currently running a telephone and email advice service.";

            MyImageSource = Agency.ImageSource;
            Website = Agency.Website;


            CallNumberCommand = new Command(CallNumber);
            WebsiteLaunchCommand = new Command(WebsiteLaunched);
            SendEmailCommand = new Command(SendEmail);

            CallText = $"Call advice line\n({Agency.ContactNumber})";
            EmailText = $"Email us\n({Agency.EmailAddress})";

        }



        async void CallNumber()
        {
            try
            {
                PhoneDialer.Open(Agency.ContactNumber);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Could not dial number",
                    "Please ensure your device is capable of making calls", "OK");
            }
        }

        void WebsiteLaunched()
        {
            Launcher.TryOpenAsync(Agency.Website);
        }

        async void SendEmail()
        {
            try
            {
                await Launcher.OpenAsync(new Uri($"mailto:{Agency.EmailAddress}"));
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Could not open email app",
                    "Unable to start an email application", "OK");
            }
        }
    }
}
