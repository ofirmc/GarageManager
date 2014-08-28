using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class Truck : CommercialFuelAutomobile
    {
        private eVehicleType m_VehicleType;

        public Truck()
        {
            VehicleWheelsArray = new Wheels[8];

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                VehicleWheelsArray[i] = new Wheels();
                VehicleWheelsArray[i].MaxAirPressureByManufacturer = 28;
            }

            this.m_VehicleType = eVehicleType.Truck;
            MaxAmountOfFuelInLiters = 150f;
            FuelType = eFuelTypes.Octan96;
        }

        /// <summary>
        /// This method collects a general part of information on an Truck vehicle
        /// </summary>
        /// <returns>string with Truck info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("Vehicle type: ");
            stringBuilder.AppendLine(this.m_VehicleType.ToString());
            stringBuilder.Append(base.ToString());
            
            return stringBuilder.ToString();
        }
    }
}
