using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using static CitizensAdvice.StaticClasses.Populator;

namespace CitizensAdvice.StaticClasses
{
    public static class Database
    {
        public static string UrlPrefix = "https://www.citizensadvice.org.uk/";

        public static Place DefaultPlace = PopulateCitizensAdvicePlace();

        public static ObservableCollection<AdviceArea> AdviceAreas = PopulateAdviceAreas();
    }
}
