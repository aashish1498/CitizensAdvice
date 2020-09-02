using System;
using System.Collections.ObjectModel;
using CitizensAdvice.Models;
using Xamarin.Forms.Maps;
using static CitizensAdvice.StaticClasses.Keywords;

namespace CitizensAdvice.StaticClasses
{
    public static class Populator
    {
        public static Place PopulateCitizensAdvicePlace()
        {
            var citizensAdviceLocation = new Position(51.558010, 0.075367); // Ilford Library

            var contactInfo = new ContactInformation(
                    "03003309063",
                    "advice@citizensadviceredbridge.org.uk",
                    "http://www.citizensadviceredbridge.org.uk/",
                    "https://www.citizensadviceredbridge.org.uk/ask-for-advice/"
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
                citizensAdviceLocation,
                "Central Library, Clements Rd, Ilford,\nIG1 1EA",
                "Citizens Advice Redbridge",
                "CitizensAdvice.Images.MainPageLogo.png",
                contactInfo,
                branchOpeningTimes,
                callOpeningTimes
            );

            return place;
        }

        public static ObservableCollection<AdviceArea> PopulateAdviceAreas()
        {

            //TODO Consider changing to a dictionary of strings to add URL


            var adviceAreas = new ObservableCollection<AdviceArea>()
            {
                new AdviceArea("Benefits", "benefits", false, BenefitsKeywords),
                new AdviceArea("Consumer", "consumer", false, ConsumerKeywords),
                new AdviceArea("Debt and Money", "debt-and-money", false, DebtAndMoneyKeywords),
                new AdviceArea("Education", "family/education", false, EducationKeywords),
                new AdviceArea("Family", "family", false, FamilyKeywords),
                new AdviceArea("Hate Crime", "law-and-courts/discrimination/hate-crime", false, HateCrimeKeywords),
                new AdviceArea("Health", "health", false, HealthKeywords),
                new AdviceArea("Housing", "housing", false, HousingKeywords),
                new AdviceArea("Immigration", "immigration", false, ImmigrationKeywords),
                new AdviceArea("Law and Courts", "law-and-courts", false, LawAndCourtsKeywords),
                new AdviceArea("Work", "work", false, WorkKeywords)
            };

            return adviceAreas;
        }
    }
}
