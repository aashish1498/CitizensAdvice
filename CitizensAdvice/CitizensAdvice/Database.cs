using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using Xamarin.Forms.Maps;

namespace CitizensAdvice
{
    public static class Database
    {
        public static string UrlPrefix = "https://www.citizensadvice.org.uk/";

        public static Position DefaultPosition = new Position(51.558010, 0.075367); // Ilford Library
        
        public static Place DefaultPlace = new Place(
            DefaultPosition,
            "Central Library, Clements Rd, Ilford IG1 1EA",
            "Citizens Advice Redbridge",
            "CitizensAdvice.Images.MainPageLogo.png"
            );

        public static ObservableCollection<AdviceArea> AdviceAreas = new ObservableCollection<AdviceArea>()
        {
            new AdviceArea("Benefits", "benefits", false),
            new AdviceArea("Consumer", "consumer", false),
            new AdviceArea("Debt and Money", "debt-and-money", false),
            new AdviceArea("Education", "family/education", false),
            new AdviceArea("Family", "family", false),
            new AdviceArea("Hate Crime", "law-and-courts/discrimination/hate-crime", false),
            new AdviceArea("Health", "health", false),
            new AdviceArea("Housing", "housing", false),
            new AdviceArea("Immigration", "immigration", false),
            new AdviceArea("Law and Courts", "law-and-courts", false),
            new AdviceArea("Work", "work", false)
        };

    }
}
