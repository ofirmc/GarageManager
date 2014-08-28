using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricTwoWheeledVehicle : ElectricVehicle
    {
        private int m_TwoWheeledVehicleEngineCC;
        private eTwoWheeledVehicleLicenseType m_TwoWheeledVehicleLicenseType;        

        public eTwoWheeledVehicleLicenseType TwoWheeledVehicleLicenseType
        {
            get { return this.m_TwoWheeledVehicleLicenseType; }
            set { this.m_TwoWheeledVehicleLicenseType = value; }
        }

        public int TwoWheeledVehicleEngineCC
        {
            get { return this.m_TwoWheeledVehicleEngineCC; }
            set { this.m_TwoWheeledVehicleEngineCC = value; }
        }

        public ElectricTwoWheeledVehicle()
        {
            VehicleWheelsArray = new Wheels[2];

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                VehicleWheelsArray[i] = new Wheels();
                VehicleWheelsArray[i].MaxAirPressureByManufacturer = 31;
            }
        }

        /// <summary>
        /// This method collects a general part of information on an Electric Two Wheeled Vehicle vehicle
        /// </summary>
        /// <returns>string with Electric Two Wheeled info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append("Owner name: ");
            stringBuilder.AppendLine(VehicleInformation.VehicleOwnerName);
            stringBuilder.Append("Car status in garage: ");
            stringBuilder.AppendLine(VehicleInformation.VehicleGarageStatus.ToString());

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
            stringBuilder.Append("License type: ");
            stringBuilder.AppendLine(this.TwoWheeledVehicleLicenseType.ToString());
            stringBuilder.Append("Vehicle Engine CC: ");
            stringBuilder.AppendLine(this.TwoWheeledVehicleEngineCC.ToString());            
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
