using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private string m_ModelName = string.Empty;
        private string m_VehicleLicenseNumber = string.Empty;
        private float m_LeftPercentageEnergySource = 0;
        private Wheels[] m_VehicleWheelsArray;        
        private VehicleInformation m_VehicleInformation = null;

        protected internal string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        protected internal string VehicleLicenseNumber
        {
            get { return m_VehicleLicenseNumber; }
            set { m_VehicleLicenseNumber = value; }
        }

        protected internal float LeftPercentageEnergySource
        {
            get { return m_LeftPercentageEnergySource; }
            set { m_LeftPercentageEnergySource = value; }
        }

        protected internal Wheels[] VehicleWheelsArray
        {
            get { return m_VehicleWheelsArray; }
            set { m_VehicleWheelsArray = value; }
        }

        protected internal VehicleInformation VehicleInformation 
        {
            get { return m_VehicleInformation; }
            set { m_VehicleInformation = value; }
        }        

        /// <summary>
        /// This method collects a general part of the information of the vehicle
        /// </summary>
        /// <returns>string with vehicle info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Vehicle license number: ");
            stringBuilder.AppendLine(VehicleLicenseNumber);
            stringBuilder.Append("Model name: ");
            stringBuilder.AppendLine(ModelName);
            stringBuilder.Append("Left Percentage Energy Source: ");
            stringBuilder.Append(LeftPercentageEnergySource.ToString());
            stringBuilder.AppendLine("%");           

            return stringBuilder.ToString();
        }       
    }
}
