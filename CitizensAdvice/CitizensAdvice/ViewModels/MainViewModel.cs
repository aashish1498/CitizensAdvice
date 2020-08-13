using System;
using CitizensAdvice.Annotations;
using CitizensAdvice.Models;
using CitizensAdvice.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CitizensAdvice.StaticClasses;
using Xamarin.Forms;
using static System.Globalization.CultureInfo;

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
            AdviceAreas = new ObservableCollection<AdviceArea>();

            foreach (var adviceArea in Database.AdviceAreas)
            {
                AdviceAreas.Add(new AdviceArea(adviceArea));
            }
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
            if (index != -1)
            {
                AdviceAreas.Insert(index, area);
            }
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

        public ICommand PerformSearch
        {
            get
            {
                return new Command<string>((string query) =>
                {
                    if (query == string.Empty)
                    {
                        OnSearchExited();
                        return;
                    }

                    // All expanded boxes will be collapsed
                    _oldArea = null;

                    query = query.ToLower();
                    AdviceAreas.Clear();

                    foreach (var adviceArea in Database.AdviceAreas)
                    {
                        // Check if the name matches the advice area
                        if (adviceArea.AreaName.ToLower().Contains(query))
                        {
                            AdviceAreas.Add(new AdviceArea(adviceArea));
                        }


                        foreach (var areaKeyword in adviceArea.Keywords)
                        {
                            var areaKeywordLower = areaKeyword.ToLower();

                            if (!areaKeywordLower.Contains(query)) continue;

                            var areaKeywordTitleCase = CurrentCulture.TextInfo.ToTitleCase(areaKeywordLower);

                            var index = areaKeywordLower.IndexOf(query, StringComparison.Ordinal);

                            string initialSubString = areaKeywordTitleCase.Substring(0, index);
                            string queryString = areaKeywordTitleCase.Substring(index, query.Length);
                            string finalSubString = String.Empty;

                            if ((index + query.Length) < areaKeywordLower.Length)
                            {
                                finalSubString =
                                    areaKeywordTitleCase.Substring(index + query.Length);
                            }

                            var formattedKeyword = new FormattedString
                            {
                                Spans =
                                {
                                    new Span
                                    {
                                        Text = $"{adviceArea.AreaName} -> ",
                                        ForegroundColor = (Color) Application.Current.Resources["PrimaryColor"]
                                    },
                                    new Span
                                    {
                                        Text = initialSubString,
                                        ForegroundColor = (Color) Application.Current.Resources["PrimaryColor"]
                                    },
                                    new Span {Text = queryString, ForegroundColor = Color.Red},
                                    new Span
                                    {
                                        Text = finalSubString,
                                        ForegroundColor = (Color) Application.Current.Resources["PrimaryColor"]
                                    }
                                }
                            };

                            var newAdviceArea = new AdviceArea(adviceArea) {KeywordFormatted = formattedKeyword};
                            AdviceAreas.Add(newAdviceArea);
                        }

                    }

                });
            }
        }


        void OnSearchExited()
        {
            AdviceAreas.Clear();
            _oldArea = null;
            foreach (var adviceArea in Database.AdviceAreas) AdviceAreas.Add(new AdviceArea(adviceArea));
        }
    }
}
