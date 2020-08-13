using System;
using System.Collections.Generic;
using System.Text;

namespace CitizensAdvice.StaticClasses
{
    public static class Keywords
    {
        public static List<string> BenefitsKeywords = new List<string>
        {
            "pension",
            "disability",
            "carers",
            "reconsideration",
            "appeal",
            "child",
            "universal credit",
            "housing",
            "bereavement",
            "sick pay",
            "mortgage",
            "council tax"
        };

        public static List<string> ConsumerKeywords = new List<string>
        {
            "car",
            "holidays",
            "transport",
            "changed mind",
            "water",
            "energy",
            "complaints",
            "scams",
            "delivery",
            "insurance",
        };

        public static List <string> DebtAndMoneyKeywords = new List<string>
            {
                "credit card", "priority", "non priority", "gas", "electricity", "rent", "mortgage", "arrears",
                "financial advice", "bankruptcy", "management", "budgeting"
            };

        public static List <string> EducationKeywords = new List<string>
            {
                "school", "university", "exams", "costs", "exclusion"
            };

        public static List <string> FamilyKeywords = new List<string>
            {
                "domestic violence", "divorce", "marriage", "children", "access", "wills", "death", "civil partnership",
                "living together", "inheritance"
            };

        public static List <string> HateCrimeKeywords = new List<string>
            {
                "hate crime", "discrimination", "domestic violence", "reporting", "racist", "disability", "gender"
            };

        public static List <string> HealthKeywords = new List<string>
            {
                "coronavirus", "GP", "elderly", "care", "costs", "complaints dentist", "self isolate", "NHS"
            };

        public static List <string> HousingKeywords = new List<string>
            {
                "Benefit", "repairs", "renting", "bidding", "eviction", "council", "housing association", "mortgage",
                "moving", "buying", "selling", "neighbors"
            };

        public static List <string> ImmigrationKeywords = new List<string>
            {
                "brexit", "asylum", "refugee", "visa", "windrush", "benefits", "status", "application"
            };

        public static List <string> LawAndCourtsKeywords = new List<string>
            {
                "court hearing", "brexit", "compensation", "parking", "small claims", "civil rights"
            };

        public static List <string> WorkKeywords = new List<string>
            {
                "furlough", "redundancy", "hours", "contract", "pay", "looking", "tribunal", "dismissal", "complaints"
            };
    }
}
