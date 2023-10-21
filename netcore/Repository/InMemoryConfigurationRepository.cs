using System;
using System.Collections.Generic;
using congestion.calculator.Stories.TaxCalculator;
using congestion.calculator.Stories.TaxCalculator.Contracts;
using congestion.calculator.Stories.TaxCalculator.Exceptions;

namespace congestion.calculator.Repository
{
   public class InMemoryConfigurationRepository : IConfigurationRepository
{
    private readonly Dictionary<string, CityConfiguration> cityConfigurations;

    public InMemoryConfigurationRepository()
    {
        cityConfigurations = new Dictionary<string, CityConfiguration>
        {
            {
                "Gothenburg",
                new CityConfiguration
                {
                    TollFees = new List<TollFee>
                    {
                        new TollFee { TimeRange = "06:00-06:29", Fee = 8 },
                        new TollFee { TimeRange = "08:30", Fee = 8 },
                        new TollFee { TimeRange = "09:00-14:00", Fee = 8 },
                        new TollFee { TimeRange = "18:00-18:29", Fee = 8 }
                    },
                    TollFreeDates = new List<DateTime>
                    {
                        new DateTime(2023, 1, 1),
                        new DateTime(2023, 3, 28),
                        new DateTime(2023, 5, 1)
                    }
                }
            },
            {
                "Sillvik",
                new CityConfiguration
                {
                    TollFees = new List<TollFee>
                    {
                        new TollFee { TimeRange = "06:00-06:29", Fee = 10 },
                        new TollFee { TimeRange = "08:30", Fee = 10 },
                        new TollFee { TimeRange = "09:00-14:00", Fee = 10 },
                        new TollFee { TimeRange = "18:00-18:29", Fee = 10 }
                    },
                    TollFreeDates = new List<DateTime>
                    {
                        new DateTime(2023, 1, 1),
                        new DateTime(2023, 4, 1),
                        new DateTime(2023, 5, 8)
                    }
                }
            }
        };
    }

    public CityConfiguration GetCityConfiguration(string cityName)
    {
        if (cityConfigurations.TryGetValue(cityName, out var config))
        {
            return config;
        }

        throw new CityConfigurationNotFoundException();
    }
}

}