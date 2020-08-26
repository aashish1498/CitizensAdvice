using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;

namespace CitizensAdvice.Models
{
    public class Place
    {
        public Position Position { get; }
        public string Address { get; }
        public string Label { get; }
        public ObservableCollection<OpeningTimes> BranchOpeningTimes { get; }
        public ObservableCollection<OpeningTimes> CallOpeningTimes { get; }
        public ImageSource ImageSource { get; set; }
        public string DistanceString { get; set; }
        public string AddressFormatted { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string EmailUrl { get; set; }

        /// <summary>
        /// Details for an agency which provides advice.
        /// </summary>
        /// <param name="position">The physical location of the area</param>
        /// <param name="address">The displayed address</param>
        /// <param name="label">The name of the agency</param>
        /// <param name="imagePath">The location of the icon image</param>
        /// <param name="contactInformation">The contact details</param>
        /// <param name="branchOpeningTimes">A collection of opening times</param>
        /// <param name="callOpeningTimes">A collection of closing times</param>
        public Place(Position position, string address, string label, string imagePath, ContactInformation contactInformation, ObservableCollection<OpeningTimes> branchOpeningTimes, ObservableCollection<OpeningTimes> callOpeningTimes)
        {
            Position = position;
            Address = address;
            Label = label;

            BranchOpeningTimes = branchOpeningTimes;
            CallOpeningTimes = callOpeningTimes;

            ContactNumber = contactInformation.ContactNumber;
            EmailAddress = contactInformation.EmailAddress;
            EmailUrl = contactInformation.EmailAddressUrl;
            Website = contactInformation.Website;

            ImageSource = ImageSource.FromResource(imagePath);

            CreateDistanceString();

            AddressFormatted = Address.Replace(',', '\n');
        }


        private async void CreateDistanceString()
        {
            try
            {
                var currentLocation = await Geolocation.GetLastKnownLocationAsync();
                var distance = Location.CalculateDistance(Position.Latitude, Position.Longitude, currentLocation,
                    DistanceUnits.Miles);
                if (distance < 1)
                {
                    distance = Math.Round(distance, 2);
                }
                else if (distance < 100)
                {
                    distance = Math.Round(distance, 1);
                }
                else
                {
                    distance = Math.Round(distance);
                }

                DistanceString = $"({distance} miles away)";
            }
            catch
            {
                DistanceString = string.Empty;
            }

        }
    }
}
