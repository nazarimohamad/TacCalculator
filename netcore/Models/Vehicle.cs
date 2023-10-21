using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public interface Vehicle
    {
        String GetVehicleType();
    }
    
    public enum TollFreeVehicles
    {
        Emergency = 1,
        Bus = 2,
        Motorbike = 3,
        Military = 4,
        Foreign = 5
    }
}