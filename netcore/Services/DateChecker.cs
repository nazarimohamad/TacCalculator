using System;

namespace congestion.calculator
{
    public static class DateChecker
    {
        private static readonly DateTime[] PublicHolidays2013 = new DateTime[]
        {
            new DateTime(2013, 1, 1),   
            new DateTime(2013, 3, 28),  
            new DateTime(2013, 3, 29),  
            new DateTime(2013, 4, 1),   
            new DateTime(2013, 5, 1), 
            new DateTime(2013, 5, 8),   
            new DateTime(2013, 5, 9),   
            new DateTime(2013, 6, 5), 
            new DateTime(2013, 6, 21),
            new DateTime(2013, 11, 1),  
            new DateTime(2013, 12, 24), 
            new DateTime(2013, 12, 25), 
            new DateTime(2013, 12, 26), 
            new DateTime(2013, 12, 31)  
        };
        
        public static bool IsTollFreeDate(DateTime date)
        {
            return IsHoliday(date) || IsWeekend(date) || IsInJuly2013(date) || IsDayBeforePublicHoliday(date);
        }
        public static bool IsHoliday(DateTime date)
        {
            return Array.Exists(PublicHolidays2013, holiday => holiday.Date == date.Date);
        }

        public static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsInJuly2013(DateTime date)
        {
            return date.Year == 2013 && date.Month == 7;
        }

        public static bool IsDayBeforePublicHoliday(DateTime date)
        {
            DateTime nextDay = date.AddDays(1);
            return IsHoliday(nextDay);
        }
    }
}