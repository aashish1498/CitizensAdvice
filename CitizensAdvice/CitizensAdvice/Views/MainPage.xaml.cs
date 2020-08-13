using System;
using System.ComponentModel;
using CitizensAdvice.Models;
using CitizensAdvice.ViewModels;
using Xamarin.Forms;

namespace CitizensAdvice.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            var area = e.Item as AdviceArea;
            vm.HideOrShowDropdown(area);
        }

        private void OnlineAdviceClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var area = button?.BindingContext as AdviceArea;
            var vm = BindingContext as MainViewModel;
            vm?.VisitWebsite.Execute(area);
        }

        private void FindAgencyClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var area = button?.BindingContext as AdviceArea;
            var vm = BindingContext as MainViewModel;
            vm?.FindAgency.Execute(area);
        }

        private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            if (sender is SearchBar searchBar) vm?.PerformSearch.Execute(searchBar.Text);
        }
    }
}
