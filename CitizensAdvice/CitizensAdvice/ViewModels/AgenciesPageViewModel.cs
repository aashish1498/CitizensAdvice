using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CitizensAdvice.Models;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace CitizensAdvice.ViewModels
{
    class AgenciesPageViewModel
    {
        public Map Map { get; set; }
        public AdviceArea Area { get; }
        public Position Position { get; set; }
        public string Address { get; set; }
        public string Label { get; set; }

        public ObservableCollection<Place> Places;
        public AgenciesPageViewModel(AdviceArea area)
        {
            Map = new Map();
            Area = area;
            // Details for Redbridge Station
            double lat = 51.576297;
            double lng = 0.045475;
            Position = new Position(lat, lng);
            Address = "Eastern Ave, Ilford, IG4 5DQ";
            Label = "Redbridge Station";
            Places = new ObservableCollection<Place>();
            Places.Add(new Place(Position, Address, Label));

            Map.ItemsSource = Places;
            var pin = new Pin {Label = Label, Position = Position, Address = Address};

            Map.Pins.Add(pin);
            Map.IsShowingUser = true;
            MoveToCurrentRegion();
        }

        async void MoveToCurrentRegion()
        {
            // TODO change this to make default view showing all pins
            var location = await Geolocation.GetLastKnownLocationAsync();
            var myPosition = new Position(location.Latitude, location.Longitude);
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(myPosition, Distance.FromMiles(2)));
        }
    }
}
