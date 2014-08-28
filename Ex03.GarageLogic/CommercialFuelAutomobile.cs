using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class CommercialFuelAutomobile : RegularFuelVehicle
    {
        private float m_CapacityInCubicMeter;
        private bool m_IsTransferringDangereusMaterials;

        public float CapacityInCubicMeter
        {
            get { return this.m_CapacityInCubicMeter; }
            set { this.m_CapacityInCubicMeter = value; }
        }

        public bool IsTransferringDangereusMaterials
        {
            get { return this.m_IsTransferringDangereusMaterials; }
            set { this.m_IsTransferringDangereusMaterials = value; }
        }

        /// <summary>
        /// This method collects a general part of information on an Commercial Fuel Automobile vehicle
        /// </summary>
        /// <returns>string with Commercial Fuel Automobile info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.Append(base.ToString());
            stringBuilder.Append("Owner name: ");
            stringBuilder.AppendLine(VehicleInformation.VehicleOwnerName);
            stringBuilder.Append("Vehicle status in garage: ");
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
            stringBuilder.Append("Capacity In Cubic Meter: ");
            stringBuilder.AppendLine(this.CapacityInCubicMeter.ToString());
            stringBuilder.Append("Transferring Dangereus Materials: ");
            stringBuilder.AppendLine(this.IsTransferringDangereusMaterials.ToString());
            stringBuilder.AppendLine();

            return stringBuilder.ToString();
        }
    }
}
