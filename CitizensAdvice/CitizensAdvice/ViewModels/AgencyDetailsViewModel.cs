using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CitizensAdvice.Models;

namespace CitizensAdvice.ViewModels
{
    class AgencyDetailsViewModel
    {
        public Place Agency { get; }
        public string Name { get; set; }
        public AgencyDetailsViewModel(Place agency)
        {
            Agency = agency;
            Name = agency.Label;
        }
    }
}
