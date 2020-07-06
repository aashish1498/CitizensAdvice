using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace CitizensAdvice.Models
{
    class Place
    {
        public Position Position { get; }
        public string Address { get; }
        public string Label { get; }

        public Place(Position position, string address, string label)
        {
            Position = position;
            Address = address;
            Label = label;
        }
    }
}
