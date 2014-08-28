using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleCreate
    {        
        private Vehicle vehicle = null;        

        public Vehicle NewVehicleInsert(eVehicleType i_VehicleType)
        {
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.RegularCar:
                    vehicle = new RegularCar();
                    break;
                case eVehicleType.RegularMotorcycle:
                    vehicle = new RegularMotorcycle();
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    break;
            }

            return vehicle;
        }
    }
}
