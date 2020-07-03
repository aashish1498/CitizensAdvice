using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using CitizensAdvice.Annotations;
using CitizensAdvice.Models;

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
            List<string> adviceAreaNames = new List<string>()
            {
                "Benefits",
                "Consumer",
                "Debt and Money",
                "Education",
                "Family",
                "Hate Crime",
                "Health",
                "Housing",
                "Immigration",
                "Law and Courts",
                "Work"
            };
            adviceAreaNames.Sort();
            AdviceAreas = new ObservableCollection<AdviceArea>();
            foreach (var name in adviceAreaNames)
            {
                AdviceAreas.Add(new AdviceArea(name));
            }
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
            var index = AdviceAreas.IndexOf(area);
            AdviceAreas.Remove(area);
            AdviceAreas.Insert(index, area);
        }
    }
}
