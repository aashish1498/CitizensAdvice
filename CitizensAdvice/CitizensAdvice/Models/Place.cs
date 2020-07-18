using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CitizensAdvice.Models
{
    public class Place
    {
        public Position Position { get; }
        public string Address { get; }
        public string Label { get; }
        public ImageSource ImageSource { get; set; }
        public Place(Position position, string address, string label, string imagePath)
        {
            Position = position;
            Address = address;
            Label = label;

            ImageSource = ImageSource.FromResource(imagePath);
        }
    }
}
