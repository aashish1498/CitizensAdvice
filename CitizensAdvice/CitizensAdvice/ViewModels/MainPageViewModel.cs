using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CitizensAdvice.Annotations;
using CitizensAdvice.Models;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        #region Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private AdviceArea _oldArea;

        public ObservableCollection<AdviceArea> AdviceAreas { get; set; }
        public MainPageViewModel()
        {
            var urlPrefix = "www.citizensadvice.org.uk/";

            AdviceAreas = new ObservableCollection<AdviceArea>()
            {
                new AdviceArea("Benefits", "benefits", false),
                new AdviceArea("Consumer", "consumer", false),
                new AdviceArea("Debt and Money", "debt-and-money", false),
                new AdviceArea("Education", "family/education", false),
                new AdviceArea("Family", "family", false),
                new AdviceArea("Hate Crime", "law-and-courts/discrimination/hate-crime", false),
                new AdviceArea("Health", "health", false),
                new AdviceArea("Housing", "housing", false),
                new AdviceArea("Immigration", "immigration", false),
                new AdviceArea("Law and Courts", "law-and-courts", false),
                new AdviceArea("Work", "work", false)
            };
        }

        public void HideOrShowDropdown(AdviceArea area)
        {
            if (_oldArea == area)
            {
                area.IsDropdownVisible = !area.IsDropdownVisible;
                UpdateAreas(area);
            }
            else
            {
                if (_oldArea != null)
                {
                    // Hide previous selected item
                    _oldArea.IsDropdownVisible = false;
                    UpdateAreas(_oldArea);
                }
                // Show selected area
                area.IsDropdownVisible = true;
                UpdateAreas(area);
            }

            _oldArea = area;
        }

        private void UpdateAreas(AdviceArea area)
        {
            // Consider disabling automatic update here
            var index = AdviceAreas.IndexOf(area);
            AdviceAreas.Remove(area);
            AdviceAreas.Insert(index, area);
        }

        public Command<AdviceArea> VisitWebsite
        {
            get
            {
                return new Command<AdviceArea>(async area =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new WebViewPage(area));
                });
            }
        }

    }
}
