using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgencyDetailsPage : ContentPage
    {
        public AgencyDetailsPage(Place agency)
        {
            InitializeComponent();
            BindingContext = new AgencyDetailsViewModel(agency);
            Title = agency.Label;
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
    }
}