using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutUsPage : ContentPage
    {
        public AboutUsPage()
        {
            InitializeComponent();
            BindingContext = new AboutUsViewModel();
            Title = "About us";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
    }
}