using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /// <summary>
        /// Copy values from an existing instance of the Advice Area
        /// </summary>
        /// <param name="previousAdviceArea"></param>
        public AdviceArea(AdviceArea previousAdviceArea)
        {
            AreaName = previousAdviceArea.AreaName;
            Keywords = previousAdviceArea.Keywords;
            AreaUrl = previousAdviceArea.AreaUrl;
            IsDropdownVisible = previousAdviceArea.IsDropdownVisible;
            Places = previousAdviceArea.Places;
            KeywordFormatted = previousAdviceArea.KeywordFormatted;
        }

        /// <summary>
        /// Create an area of Advice provided by CAR
        /// </summary>
        /// <param name="name">Name of the Advice Area e.g. 'Benefits'</param>
        /// <param name="areaUrl">The website URL corresponding to the Advice Area</param>
        /// <param name="containsPrefix">If false, the prefix 'https://www.citizensadvice.org.uk/' will be added to the areaUrl parameter</param>
        /// <param name="keywords">A list of searchable keywords that will direct to the Advice Area</param>
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
