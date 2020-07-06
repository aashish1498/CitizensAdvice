using System;
using System.Collections.Generic;
using System.Text;

namespace CitizensAdvice.Models
{
    public class Agency
    {
        public string Name { get; }
        public bool IsCitizensAdvice { get; }

        public Agency(string name, bool isCitizensAdvice)
        {
            Name = name;
            IsCitizensAdvice = isCitizensAdvice;
            
        }
    }
}
