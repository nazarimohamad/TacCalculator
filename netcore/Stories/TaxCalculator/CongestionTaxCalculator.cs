using System;
using congestion.calculator;
using congestion.calculator.Stories.TaxCalculator.Contracts;

public class CongestionTaxCalculator
{
    private readonly IConfigurationRepository configRepository;

    public CongestionTaxCalculator(IConfigurationRepository repository)
    {
        configRepository = repository;
    }
    
    public int GetTax(Vehicle vehicle, DateTime[] dates, string city)
    {
        DateTime intervalStart = dates[0];
        int totalFee = 0;
        var cityConfig = configRepository.GetCityConfiguration(city);
        
        if (VehicleChecker.IsTollFreeVehicle(vehicle) || dates == null || dates.Length == 0)
        {
            return 0;
        }
       
        foreach (DateTime date in dates)
        {
            // To Implement application for cities with different tax rules
            // int nextFee = cityConfig.GetTollFee(date);
            // int tempFee = cityConfig.GetTollFee(intervalStart);
            
            int nextFee = GetTollFee(date);
            int tempFee = GetTollFee(intervalStart);

            long diffInMillies = date.Millisecond - intervalStart.Millisecond;
            long minutes = diffInMillies / 1000 / 60;

            if (minutes <= 60)
            {
                if (totalFee > 0) totalFee -= tempFee;
                if (nextFee >= tempFee) tempFee = nextFee;
                totalFee += tempFee;
            }
            else
            {
                totalFee += nextFee;
            }
        }
        if (totalFee > 60) totalFee = 60;
        return totalFee;
    }
    private int GetTollFee(DateTime date)
    {
        if (DateChecker.IsTollFreeDate(date)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        if ((hour == 6 && minute >= 0 && minute <= 29) || 
            (hour == 8 && minute >= 30) || 
            (hour >= 9 && hour <= 14) ||  
            (hour == 18 && minute >= 0 && minute <= 29)) 
        {
            return 8;
        }
        else if ((hour == 6 && minute >= 30) ||
                 (hour == 8 && minute >= 0 && minute <= 29) ||
                 (hour == 15 && minute >= 0 && minute <= 29) || 
                 (hour == 17)
                )
        {
            return 13;
        }
        else if ((hour == 15 && minute >= 30) || 
                 (hour == 16) || 
                 (hour == 7)) 
        {
            return 18;
        }
        return 0;
    }
}

