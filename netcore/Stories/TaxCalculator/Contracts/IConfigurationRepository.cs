namespace congestion.calculator.Stories.TaxCalculator.Contracts
{
    public interface IConfigurationRepository
    {
        CityConfiguration GetCityConfiguration(string cityName);
    }
}