using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleInformation
    {
        private string m_VehicleOwnerName = string.Empty;
        private string m_VehicleOwnerPhone = string.Empty;
        private eVehicleGarageStatus m_VehicleGarageStatus;        

        public eVehicleGarageStatus VehicleGarageStatus 
        {
            get { return m_VehicleGarageStatus; }
            set { m_VehicleGarageStatus = value; }
        }

        public string VehicleOwnerName 
        {
            get { return m_VehicleOwnerName; }
            set { m_VehicleOwnerName = value; }
        }

        public string VehicleOwnerPhone 
        {
            get { return m_VehicleOwnerPhone; }
            set { m_VehicleOwnerPhone = value; }
        }

        public VehicleInformation()
        {
            VehicleGarageStatus = eVehicleGarageStatus.InRepair;
        }
    }
}
