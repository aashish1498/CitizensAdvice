using CitizensAdvice.Annotations;
using CitizensAdvice.Models;
using CitizensAdvice.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace CitizensAdvice.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
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
        public MainViewModel()
        {
            AdviceAreas = Database.AdviceAreas;
            // TODO add more agency places to each area here
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

        public Command<AdviceArea> FindAgency
        {
            get
            {
                return new Command<AdviceArea>(async area =>
                {
                    await Application.Current.MainPage.Navigation.PushAsync(new AgenciesListPage(area));
                });
            }
        }
    }
}
