using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CitizensAdvice.Models;

namespace CitizensAdvice
{
    public static class Database
    {
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

        public static string UrlPrefix = "https://www.citizensadvice.org.uk/";
    }
}
