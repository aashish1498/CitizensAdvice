using System;
using System.Collections.Generic;
using System.Text;

namespace CitizensAdvice.Models
{
    public class AdviceArea
    {
        public string AreaName { get; set; }
        public string AreaUrl { get; set; }
        public bool IsDropdownVisible { get; set; }

        public AdviceArea(string name, string areaUrl, bool containsPrefix)
        {
            const string urlPrefix = "https://www.citizensadvice.org.uk/";
            AreaName = name;
            if (containsPrefix)
            {
                AreaUrl = areaUrl;
            }
            else
            {
                AreaUrl = urlPrefix + areaUrl;
            }
            
        }
    }
}
