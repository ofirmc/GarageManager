using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal sealed class ElectricCar : ElectricAutomobile
    {
        private eVehicleType m_VehicleType;

        public ElectricCar()
        {            
            MaxBatteryLifeTimeInHours = 2.5f;
            this.m_VehicleType = eVehicleType.ElectricCar;
        }

        /// <summary>
        /// This method collects a general part of information on an Electric Car Vehicle
        /// </summary>
        /// <returns>string with Electric Car info parameters</returns>
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
