using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using CitizensAdvice.Views;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class AgenciesListViewModel
    {
        public AdviceArea Area { get; }

        public ObservableCollection<Place> Places { get; set; }


        public AgenciesListViewModel(AdviceArea area)
        {
            Area = area;
            Places = area.Places;
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
