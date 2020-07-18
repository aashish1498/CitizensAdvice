using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using CitizensAdvice.Models;
using Xamarin.Forms.Maps;

namespace CitizensAdvice
{
    public static class Database
    {
        public static string UrlPrefix = "https://www.citizensadvice.org.uk/";

        public static Position DefaultPosition = new Position(51.558010, 0.075367); // Ilford Library

        public static Place DefaultPlace = PopulateCitizensAdvicePlace();

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

        static Place PopulateCitizensAdvicePlace()
        {
            //TODO change this to actual email address

            var contactInfo = new ContactInformation(
                "03003309063",
                "aashish.mehta@citizensadviceredbridge.org.uk",
                "http://www.citizensadviceredbridge.org.uk/"
                );

            var branchOpeningTimes = new ObservableCollection<OpeningTimes>
            {
                new OpeningTimes(DayOfWeek.Monday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new OpeningTimes(DayOfWeek.Tuesday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new OpeningTimes(DayOfWeek.Wednesday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new OpeningTimes(DayOfWeek.Thursday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new OpeningTimes(DayOfWeek.Friday, new TimeSpan(9, 0, 0), new TimeSpan(17, 0, 0)),
                new OpeningTimes(DayOfWeek.Saturday, TimeSpan.Zero, TimeSpan.Zero),
                new OpeningTimes(DayOfWeek.Sunday, TimeSpan.Zero, TimeSpan.Zero),
            };

            var callOpeningTimes = branchOpeningTimes;

            var place = new Place(
                DefaultPosition,
                "Central Library, Clements Rd, Ilford,\nIG1 1EA",
                "Citizens Advice Redbridge",
                "CitizensAdvice.Images.MainPageLogo.png",
                contactInfo,
                branchOpeningTimes,
                callOpeningTimes
            );

            return place;
        }

    }
}
