using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class RegularCar : RegularFuelAutomobile
    {
        private eVehicleType m_VehicleType;

        public RegularCar()
        {
            MaxAmountOfFuelInLiters = 55f;
            FuelType = eFuelTypes.Octan98;
            this.m_VehicleType = eVehicleType.RegularCar;
        }

        /// <summary>
        /// This method collects a general part of information on an Regular Car vehicle
        /// </summary>
        /// <returns>string with Regular Car info parameters</returns>
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
