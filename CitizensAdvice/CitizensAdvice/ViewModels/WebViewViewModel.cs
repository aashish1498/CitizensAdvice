using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CitizensAdvice.Models;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class WebViewViewModel
    {
        public AdviceArea Area { get; }
        public string Url { get; set; }
        public WebView MyWebView;
        public Command GoBackCommand { get; set; }
        public Command GoForwardCommand { get; set; }
        public WebViewViewModel(AdviceArea area)
        {
            GoBackCommand = new Command(GoBack);
            GoForwardCommand = new Command(GoForward);
            Area = area;
            Url = area.AreaUrl;
        }

        async void GoBack()
        {
            if (MyWebView == null)
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                if (MyWebView.CanGoBack)
                {
                    MyWebView.GoBack();
                }
                else
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        void GoForward()
        {
            if (MyWebView == null) return;
            if (MyWebView.CanGoForward)
            {
                MyWebView.GoForward();
            }
        }

    }
}
