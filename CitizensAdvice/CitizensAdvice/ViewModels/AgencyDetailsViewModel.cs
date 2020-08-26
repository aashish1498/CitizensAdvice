using System;
using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using CitizensAdvice.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CitizensAdvice.ViewModels
{
    class AgencyDetailsViewModel
    {
        public Place Agency { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Command CallNumberCommand { get; set; }
        public Command WebsiteLaunchCommand { get; set; }
        public Command SendEmailCommand { get; set; }
        public string Number { get; set; }
        public string CallText { get; set; }
        public ObservableCollection<OpeningTimes> BranchOpeningTimes { get; set; }
        public ObservableCollection<OpeningTimes> CallOpeningTimes { get; set; }
        public string Website { get; set; }
        public ImageSource MyImageSource { get; set; }


        public AgencyDetailsViewModel(Place agency)
        {
            Agency = agency;
            Name = agency.Label;
            Number = agency.ContactNumber;
            Address = agency.Address;

            BranchOpeningTimes = agency.BranchOpeningTimes;
            CallOpeningTimes = agency.CallOpeningTimes;

            Website = agency.Website;
            MyImageSource = agency.ImageSource;

            CallNumberCommand = new Command(CallNumber);
            WebsiteLaunchCommand = new Command(WebsiteLaunched);
            SendEmailCommand = new Command(SendEmail);

            CallText = $"Call advice line\n({Number})";
        }


        async void CallNumber()
        {
            try
            {
                PhoneDialer.Open(Number);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Could not dial number",
                    "Please ensure your device is capable of making calls", "OK");
            }
        }

        void WebsiteLaunched()
        {
            Launcher.TryOpenAsync(Website);
        }

        async void SendEmail()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage(Agency));
        }

    }
}
