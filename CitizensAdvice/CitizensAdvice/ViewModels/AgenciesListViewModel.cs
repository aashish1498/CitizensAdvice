using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CitizensAdvice.Models;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class AgenciesListViewModel
    {
        public AdviceArea Area { get; }

        public ObservableCollection<Place> Places { get; set; }
        public Command ViewOnMapCommand { get; }


        public AgenciesListViewModel(AdviceArea area)
        {
            ViewOnMapCommand = new Command(ViewOnMap);
            Area = area;
            Places = area.places;
        }

        private async void ViewOnMap()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AgenciesPage(Area));
        }

        public Command<Place> DisplayAgencyDetails
        {
            get
            {
                return new Command<Place>(async place =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new AgencyDetailsPage(place));

                });
            }
        }
    }
}
