using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class RegularFualTwoWheeledVehicle : RegularFuelVehicle
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

        public RegularFualTwoWheeledVehicle()
        {
            VehicleWheelsArray = new Wheels[2];

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                VehicleWheelsArray[i] = new Wheels();
                VehicleWheelsArray[i].MaxAirPressureByManufacturer = 31;
            }
        }

        /// <summary>
        /// This method collects a general part of information on an regular fuel two wheeled vehicle
        /// </summary>
        /// <returns>string with regular fuel two wheeled info parameters</returns>
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
            stringBuilder.Append("License type: ");
            stringBuilder.AppendLine(this.TwoWheeledVehicleLicenseType.ToString());
            stringBuilder.Append("Vehicle Engine CC: ");
            stringBuilder.AppendLine(this.TwoWheeledVehicleEngineCC.ToString());                       

            return stringBuilder.ToString();
        }
    }
}
