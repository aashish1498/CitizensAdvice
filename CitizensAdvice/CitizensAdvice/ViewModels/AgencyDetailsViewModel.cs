using System;
using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Map = Xamarin.Forms.Maps.Map;

namespace CitizensAdvice.ViewModels
{
    class AgencyDetailsViewModel
    {
        public Place Agency { get; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Map Map { get; set; }
        public Command CallNumberCommand { get; set; }
        public Command WebsiteLaunchCommand { get; set; }
        public Command SendEmailCommand { get; set; }
        public Command GetDirectionsCommand { get; set; }
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

            Map = new Map();

            Map.Pins.Add(new Pin
            {
                Label = agency.Label,
                Position = agency.Position,
                Address = agency.Address
            });

            Map.MoveToRegion(MapSpan.FromCenterAndRadius(agency.Position, Distance.FromMiles(0.1)));

            CallNumberCommand = new Command(CallNumber);
            WebsiteLaunchCommand = new Command(WebsiteLaunched);
            SendEmailCommand = new Command(SendEmail);
            GetDirectionsCommand = new Command(GetDirections);

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

        void SendEmail()
        {
            //TODO Populate this
        }

        void GetDirections()
        {
            var options = new MapLaunchOptions
            {
                NavigationMode = NavigationMode.Walking,
                Name = Name
            };

            Xamarin.Essentials.Map.OpenAsync(new Location(Agency.Position.Latitude, Agency.Position.Longitude), options);
        }
    }
}
