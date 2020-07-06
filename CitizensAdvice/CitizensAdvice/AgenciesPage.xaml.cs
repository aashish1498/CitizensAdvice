using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgenciesPage : ContentPage
    {
        public AgenciesPage(AdviceArea area)
        {
            InitializeComponent();
            BindingContext = new AgenciesPageViewModel(area);
            Title = area.AreaName + " agencies";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }
    }
}