using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CitizensAdvice.StaticClasses;
using Xamarin.Forms;

namespace CitizensAdvice.Models
{
    public class AdviceArea
    {
        public string AreaName { get; set; }
        public List<string> Keywords { get; }
        public string AreaUrl { get; set; }
        public bool IsDropdownVisible { get; set; }
        public ObservableCollection<Place> Places { get; set; }
        public FormattedString KeywordFormatted { get; set; }

        public bool IsKeywordVisible => !string.IsNullOrEmpty(KeywordFormatted.ToString());

        public AdviceArea(AdviceArea previousAdviceArea)
        {
            AreaName = previousAdviceArea.AreaName;
            Keywords = previousAdviceArea.Keywords;
            AreaUrl = previousAdviceArea.AreaUrl;
            IsDropdownVisible = previousAdviceArea.IsDropdownVisible;
            Places = previousAdviceArea.Places;
            KeywordFormatted = previousAdviceArea.KeywordFormatted;
        }

        public AdviceArea(string name, string areaUrl, bool containsPrefix, List<string> keywords = null)
        {
            AreaName = name;
            Keywords = keywords ?? new List<string>();

            if (containsPrefix)
            {
                AreaUrl = areaUrl;
            }
            else
            {
                AreaUrl = Database.UrlPrefix + areaUrl;
            }

            Places = new ObservableCollection<Place>
            {
                Database.DefaultPlace
            };

            KeywordFormatted = new FormattedString();
        }
    }
}
