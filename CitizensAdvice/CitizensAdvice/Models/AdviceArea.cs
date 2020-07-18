﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CitizensAdvice.Models
{
    public class AdviceArea
    {
        public string AreaName { get; set; }
        public string AreaUrl { get; set; }
        public bool IsDropdownVisible { get; set; }
        public ObservableCollection<Place> Places { get; set; }

        public AdviceArea(string name, string areaUrl, bool containsPrefix)
        {
            AreaName = name;
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
            
        }
    }
}
