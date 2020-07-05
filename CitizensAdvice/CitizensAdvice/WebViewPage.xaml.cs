using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CitizensAdvice
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage(AdviceArea area)
        {
            InitializeComponent();
            BindingContext = new WebViewPageViewModel(area);
            Title = area.AreaName + " Web Info";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = (Color) Application.Current.Resources["PrimaryColor"];
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;
        }

        private void WebView1_OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var vm = BindingContext as WebViewPageViewModel;
            vm.MyWebView = sender as WebView;
        }
    }
}