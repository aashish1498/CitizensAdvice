using System;
using System.Collections.Generic;
using System.Text;

namespace CitizensAdvice.Models
{
    public class AdviceArea
    {
        public string AreaName { get; set; }
        public bool IsDropdownVisible { get; set; }

        public AdviceArea(string name)
        {
            AreaName = name;
        }
    }
}
