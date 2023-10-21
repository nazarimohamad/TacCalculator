using System;
using System.Collections.Generic;

namespace congestion.calculator.Stories.TaxCalculator
{
    public class CityConfiguration
    {
        public List<TollFee> TollFees { get; set; }
        public List<DateTime> TollFreeDates { get; set; }

        public int GetTollFee(DateTime date)
        {
            foreach (var tollFee in TollFees)
            {
                var timeRanges = tollFee.TimeRange.Split('-');
                if (timeRanges.Length == 2)
                {
                    var startTime = DateTime.Parse(timeRanges[0]);
                    var endTime = DateTime.Parse(timeRanges[1]);

                    if (date.TimeOfDay >= startTime.TimeOfDay && date.TimeOfDay <= endTime.TimeOfDay)
                    {
                        return tollFee.Fee;
                    }
                }
            }
            return 0; 
        }

        public bool IsTollFreeDate(DateTime date)
        {
            return TollFreeDates.Contains(date.Date);
        }
    }
}