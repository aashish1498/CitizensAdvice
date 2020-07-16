using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgenciesListPage : ContentPage
    {
        public AgenciesListPage(AdviceArea area)
        {
            InitializeComponent();
            BindingContext = new AgenciesListViewModel(area);
            Title = area.AreaName + " agencies";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        private void AgenciesListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv) lv.SelectedItem = null;
            var vm = BindingContext as AgenciesListViewModel;
            var place = e.Item as Place;
            vm?.DisplayAgencyDetails.Execute(place);
        }
    }
}