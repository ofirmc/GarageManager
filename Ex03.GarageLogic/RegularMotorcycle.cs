using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class RegularMotorcycle : RegularFualTwoWheeledVehicle
    {
        private eVehicleType m_VehicleType;

        public RegularMotorcycle()
        {
            MaxAmountOfFuelInLiters = 7f;
            FuelType = eFuelTypes.Octan95;
            this.m_VehicleType = eVehicleType.RegularMotorcycle;
        }

        /// <summary>
        /// This method collects a general part of information on an Regular Motorcycle vehicle
        /// </summary>
        /// <returns>string with Regular Motorcycle info parameters</returns>
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
