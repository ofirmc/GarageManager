using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricAutomobile : ElectricVehicle
    {
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;        

        protected internal eCarColor CarColor
        {
            get { return this.m_CarColor; }
            set { this.m_CarColor = value; }
        }

        protected internal eNumberOfDoors NumberOfDoors
        {
            get { return this.m_NumberOfDoors; }
            set { this.m_NumberOfDoors = value; }
        }

        public ElectricAutomobile()
        {
            VehicleWheelsArray = new Wheels[4];

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                VehicleWheelsArray[i] = new Wheels();
                VehicleWheelsArray[i].MaxAirPressureByManufacturer = 28;
            }
        }

        /// <summary>
        /// This method collects a general part of information on an Electric Automobile vehicle
        /// </summary>
        /// <returns>string with Electric Automobile info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append("Owner name: ");
            stringBuilder.AppendLine(VehicleInformation.VehicleOwnerName);
            stringBuilder.Append("Car status in garage: ");
            stringBuilder.AppendLine(VehicleInformation.VehicleGarageStatus.ToString());
            stringBuilder.AppendLine();

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                stringBuilder.Append("Wheel number ");
                stringBuilder.Append(i + 1);
                stringBuilder.AppendLine(":");
                stringBuilder.Append("Air pressure: ");
                stringBuilder.AppendLine(VehicleWheelsArray[i].CurrentAirPressure.ToString());
                stringBuilder.Append("ManufacturerName: ");
                stringBuilder.AppendLine(VehicleWheelsArray[i].ManufacturerName);
            }

            stringBuilder.AppendLine();
            stringBuilder.Append("Car color: ");
            stringBuilder.AppendLine(this.CarColor.ToString());
            stringBuilder.Append("Number of doors: ");
            stringBuilder.AppendLine(this.NumberOfDoors.ToString());
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
