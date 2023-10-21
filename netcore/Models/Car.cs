using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace congestion.calculator
{
    public class Car : Vehicle
    {
        public string CarType { get; set; }

        public Car(string carType)
        {
            this.CarType = carType;
        }
        public String GetVehicleType()
        {
            return CarType;
        }
    }
}