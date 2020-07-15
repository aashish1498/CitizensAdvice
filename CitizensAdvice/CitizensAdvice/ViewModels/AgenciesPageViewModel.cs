using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ObservableCollection<Place> Places;
        public AgenciesPageViewModel(AdviceArea area)
        {
            Map = new Map();
            Area = area;
            Places = area.places;

           //Map.ItemsSource = Places;
            foreach (var place in area.places)
            {
                Map.Pins.Add(new Pin
                {
                    Label = place.Label,
                    Position = place.Position,
                    Address = place.Address
                });
            }

            Map.IsShowingUser = true;
            MoveToCurrentRegion();
        }

        async void MoveToCurrentRegion()
        {
            // TODO change this to make default view showing all pins
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                var myPosition = new Position(location.Latitude, location.Longitude);
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(myPosition, Distance.FromMiles(2)));
            }
            catch
            {
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(Map.Pins.FirstOrDefault().Position, Distance.FromMiles(2)));
            }
        }
    }
}
