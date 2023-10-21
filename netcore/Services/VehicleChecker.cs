using System;

namespace congestion.calculator
{
    public static class VehicleChecker
    {
        public static bool IsTollFreeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return false;
            String vehicleType = vehicle.GetVehicleType();
            return Enum.TryParse(vehicleType, out TollFreeVehicles type) && 
                   IsTollFreeVehicle(type);
        }
        public static bool IsTollFreeVehicle(TollFreeVehicles type)
        {
            return type == TollFreeVehicles.Emergency ||
                   type == TollFreeVehicles.Bus ||
                   type == TollFreeVehicles.Motorbike ||
                   type == TollFreeVehicles.Military ||
                   type == TollFreeVehicles.Foreign;
        }
    }
}