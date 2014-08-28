using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class ElectricMotorcycle : ElectricTwoWheeledVehicle
    {       
        private eVehicleType m_VehicleType;        

        public ElectricMotorcycle()
        {
            MaxBatteryLifeTimeInHours = 2.2f;
            this.m_VehicleType = eVehicleType.ElectricMotorcycle;
        }

        /// <summary>
        /// This method collects a general part of information on an Electric Motorcycle Vehicle
        /// </summary>
        /// <returns>string with Electric Motorcycle info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.Append("Vehicle type: ");
            stringBuilder.AppendLine(this.m_VehicleType.ToString());
            stringBuilder.Append(base.ToString());            
            stringBuilder.Append("Max Battery Life Time In Hours: ");
            stringBuilder.AppendLine(MaxBatteryLifeTimeInHours.ToString());            

            return stringBuilder.ToString();
        }
    }
}
