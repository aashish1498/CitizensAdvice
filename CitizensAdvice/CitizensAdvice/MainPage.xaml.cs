using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;

namespace CitizensAdvice
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainPageViewModel;
            var area = e.Item as AdviceArea;
            vm.HideOrShowDropdown(area);
        }

        private void OnlineAdviceClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var area = button?.BindingContext as AdviceArea;
            var vm = BindingContext as MainPageViewModel;
            vm?.VisitWebsite.Execute(area);
        }
    }
}
