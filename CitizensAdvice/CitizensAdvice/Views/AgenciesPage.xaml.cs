using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgenciesPage : ContentPage
    {
        public AgenciesPage(AdviceArea area)
        {
            InitializeComponent();
            BindingContext = new AgenciesViewModel(area);
            Title = area.AreaName + " agencies";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
    }
}