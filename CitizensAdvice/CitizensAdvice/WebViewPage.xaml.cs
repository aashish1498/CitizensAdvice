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

        }

        private void WebView1_OnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var vm = BindingContext as WebViewPageViewModel;
            vm.MyWebView = sender as WebView;
        }
    }
}