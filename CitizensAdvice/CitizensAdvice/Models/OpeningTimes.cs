using System;
using Xamarin.Forms;

namespace CitizensAdvice.Models
{
    public class OpeningTimes
    {
        public DayOfWeek Day { get; }
        public TimeSpan OpeningTime { get; }
        public TimeSpan ClosingTime { get; }
        public string  TimesString { get; set; }

        public Color TextColor { get; set; }

        private string _dayString;

        public string DayString
        {
            get => Day.ToString();
            set => _dayString = value;
        }


        /// <summary>
        /// A class holding opening and closing times for a particular day of the week
        /// </summary>
        /// <param name="day">The day of the week</param>
        /// <param name="openingTime">The opening time. Use TimeSpan.Zero if the store is closed.</param>
        /// <param name="closingTime">The closing time. Use TimeSpan.Zero if the store is closed.</param>
        public OpeningTimes(DayOfWeek day,  TimeSpan openingTime, TimeSpan closingTime)
        {
            Day = day;
            OpeningTime = openingTime;
            ClosingTime = closingTime;

            if (openingTime == TimeSpan.Zero || closingTime == TimeSpan.Zero)
            {
                TimesString = "Closed";
            }
            else
            {
                TimesString = openingTime.ToString(@"hh\:mm") + " - " + closingTime.ToString(@"hh\:mm");
            }

            var currentDateTime = DateTime.Now;
            var currentTime = currentDateTime.TimeOfDay;

            if (currentDateTime.DayOfWeek == Day)
            {
                if (openingTime < currentTime && currentTime < closingTime && openingTime != TimeSpan.Zero)
                {
                    // It is open
                    TextColor = Color.ForestGreen;
                }
                else
                {
                    // It is closed
                    TextColor = Color.Red;
                }
            }
            else
            {
                TextColor = (Color)Application.Current.Resources["PrimaryColor"];
            }
        }
    }
}
