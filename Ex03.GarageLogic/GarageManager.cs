using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Vehicle m_Vehicle = null;
        private VehicleCreate m_VehicleCreate = null;
        private ElectricMotorcycle m_ElectricMotorcycle = null;
        private RegularMotorcycle m_RegularMotorcycle = null;
        private ElectricCar m_ElectricCar = null;
        private RegularCar m_RegularCar = null;
        private Truck m_Truck = null;
        private List<Vehicle> m_VehicleObjectsCollection = new List<Vehicle>();
        private VehicleInformation m_VehicleInformation = null;
        private eCarColor m_CarColor;
        private eVehicleType m_VehicleType;
        private eNumberOfDoors m_NumberOfDoors;
        private Wheels[] m_WheelsCollection = null;
        private float m_BatteryTimeLeftInHours = 0;
        private int m_NumberOfWheels = 0;
        private float m_CurrentAmontOfFuelInLiters = 0;
        private int m_TwoWheeledVehicleEngineCC = 0;
        private eTwoWheeledVehicleLicenseType m_TwoWheeledVehicleLicenseType;
        private float m_CapacityInCubicMeter = 0;
        private bool m_IsTransferringDangereusMaterials;

        public GarageManager()
        {
        }

        public int NumberOfWheels
        {
            get { return m_NumberOfWheels; }
            set { m_NumberOfWheels = value; }
        }

        private List<Vehicle> VehicleObjectsCollection
        {
            get { return m_VehicleObjectsCollection; }
            set { m_VehicleObjectsCollection = value; }
        }

        public Wheels[] WheelsCollection
        {
            get { return m_WheelsCollection; }
            set { m_WheelsCollection = value; }
        }

        public Type NewVehicleCreate(eVehicleType i_VehicleType)
        {
            m_VehicleType = i_VehicleType;
            m_VehicleCreate = new VehicleCreate();
            m_Vehicle = m_VehicleCreate.NewVehicleInsert(i_VehicleType);
            Type baseClassType = m_Vehicle.GetType().BaseType;
            return baseClassType;
        }

        public void NewVehicleInsert(
            string i_VehicleLicenseNumber,
            string i_ModelName,
            eCarColor i_CarColor,
            eNumberOfDoors i_NumberOfDoors,
            string i_VehicleOwnerName,
            string i_VehicleOwnerPhone,
            float i_BatteryTimeLeftInHours,
            float i_CurrentAmontOfFuelInLiters,
            int i_TwoWheeledVehicleEngineCC,
            eTwoWheeledVehicleLicenseType i_TwoWheeledVehicleLicenseType,
            float i_CapacityInCubicMeter,
            bool i_IsTransferringDangereusMaterials)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
            m_BatteryTimeLeftInHours = i_BatteryTimeLeftInHours;
            m_CurrentAmontOfFuelInLiters = i_CurrentAmontOfFuelInLiters;
            m_TwoWheeledVehicleEngineCC = i_TwoWheeledVehicleEngineCC;
            m_TwoWheeledVehicleLicenseType = i_TwoWheeledVehicleLicenseType;
            m_CapacityInCubicMeter = i_CapacityInCubicMeter;
            m_IsTransferringDangereusMaterials = i_IsTransferringDangereusMaterials;

            m_Vehicle.VehicleLicenseNumber = i_VehicleLicenseNumber;
            m_Vehicle.ModelName = i_ModelName;

            m_VehicleInformation = new VehicleInformation();
            m_VehicleInformation.VehicleOwnerName = i_VehicleOwnerName;
            m_VehicleInformation.VehicleOwnerPhone = i_VehicleOwnerPhone;
            m_Vehicle.VehicleInformation = m_VehicleInformation;
            NumberOfWheels = m_Vehicle.VehicleWheelsArray.Length;
        }

        public void InsertToVehicleObjectsCollection()
        {
            switch (m_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    NewElectricCarInsert();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    NewElectricMotorcycleInsert();
                    break;
                case eVehicleType.RegularCar:
                    NewRegularCarInsert();
                    break;
                case eVehicleType.RegularMotorcycle:
                    NewRegularMotorcycleInsert();
                    break;
                case eVehicleType.Truck:
                    NewTruckInsert();
                    break;
            }

            m_VehicleObjectsCollection.Add(m_Vehicle);
        }

        private void NewTruckInsert()
        {
            m_Truck = m_Vehicle as Truck;

            if (m_Truck != null)
            {
                m_Truck.CapacityInCubicMeter = m_CapacityInCubicMeter;
                m_Truck.IsTransferringDangereusMaterials = m_IsTransferringDangereusMaterials;
                m_Truck.VehicleWheelsArray = WheelsCollection;
                m_Truck.CurrentAmontOfFuelInLiters = m_CurrentAmontOfFuelInLiters;
                m_Truck.LeftPercentageEnergySource = (m_CurrentAmontOfFuelInLiters / m_Truck.MaxAmountOfFuelInLiters) * 100;
            }
        }

        private void NewElectricMotorcycleInsert()
        {
            m_ElectricMotorcycle = m_Vehicle as ElectricMotorcycle;

            if (m_ElectricMotorcycle != null)
            {
                m_ElectricMotorcycle.TwoWheeledVehicleEngineCC = m_TwoWheeledVehicleEngineCC;
                m_ElectricMotorcycle.TwoWheeledVehicleLicenseType = m_TwoWheeledVehicleLicenseType;
                m_ElectricMotorcycle.VehicleWheelsArray = WheelsCollection;
                m_ElectricMotorcycle.BatteryTimeLeftInHours = m_BatteryTimeLeftInHours;
                m_ElectricMotorcycle.LeftPercentageEnergySource = (m_BatteryTimeLeftInHours / m_ElectricMotorcycle.MaxBatteryLifeTimeInHours) * 100;
            }
        }

        private void NewRegularMotorcycleInsert()
        {
            m_RegularMotorcycle = m_Vehicle as RegularMotorcycle;

            if (m_RegularMotorcycle != null)
            {
                m_RegularMotorcycle.TwoWheeledVehicleEngineCC = m_TwoWheeledVehicleEngineCC;
                m_RegularMotorcycle.TwoWheeledVehicleLicenseType = m_TwoWheeledVehicleLicenseType;
                m_RegularMotorcycle.VehicleWheelsArray = WheelsCollection;
                m_RegularMotorcycle.CurrentAmontOfFuelInLiters = m_CurrentAmontOfFuelInLiters;
                m_RegularMotorcycle.LeftPercentageEnergySource = (m_CurrentAmontOfFuelInLiters / m_RegularMotorcycle.MaxAmountOfFuelInLiters) * 100;
            }
        }

        private void NewElectricCarInsert()
        {
            m_ElectricCar = m_Vehicle as ElectricCar;

            if (m_ElectricCar != null)
            {
                m_ElectricCar.CarColor = m_CarColor;
                m_ElectricCar.NumberOfDoors = m_NumberOfDoors;
                m_ElectricCar.VehicleWheelsArray = WheelsCollection;
                m_ElectricCar.BatteryTimeLeftInHours = m_BatteryTimeLeftInHours;
                m_ElectricCar.LeftPercentageEnergySource = (m_BatteryTimeLeftInHours / m_ElectricCar.MaxBatteryLifeTimeInHours) * 100;
            }
        }

        private void NewRegularCarInsert()
        {
            m_RegularCar = m_Vehicle as RegularCar;

            if (m_RegularCar != null)
            {
                m_RegularCar.CarColor = m_CarColor;
                m_RegularCar.NumberOfDoors = m_NumberOfDoors;
                m_RegularCar.VehicleWheelsArray = WheelsCollection;
                m_RegularCar.CurrentAmontOfFuelInLiters = m_CurrentAmontOfFuelInLiters;
                m_RegularCar.LeftPercentageEnergySource = (m_CurrentAmontOfFuelInLiters / m_RegularCar.MaxAmountOfFuelInLiters) * 100;
            }
        }

        public bool CarExist(string i_VehicleLicenseNumberStr)
        {
            bool carExist = true;

            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    carExist = false;
                }
            }

            return carExist;
        }

        public bool CheckCarExistInRepairFallback(string i_VehicleLicenseNumberStr)
        {
            bool carExist = true;

            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    carExist = false;
                    vehicle.VehicleInformation.VehicleGarageStatus = eVehicleGarageStatus.InRepair;
                }
            }

            return carExist;
        }

        public void RechargeElectricVehicleBattery(string i_VehicleLicenseNumberStr, float i_ChargeBatteryTimeToAdd)
        {
            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    ElectricVehicle electricVehicle = vehicle as ElectricVehicle;
                    if (electricVehicle != null)
                    {
                        electricVehicle.RechargeBattery(i_ChargeBatteryTimeToAdd);
                    }
                }
            }
        }

        public void RefillFuelVehicle(string i_VehicleLicenseNumberStr, eFuelTypes i_FuelTypes, float i_FuelAmoutToAddInLiters)
        {
            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    RegularFuelVehicle regularFuelVehicle = vehicle as RegularFuelVehicle;
                    if (regularFuelVehicle != null)
                    {
                        regularFuelVehicle.FuelRefill(i_FuelAmoutToAddInLiters, i_FuelTypes);
                    }
                }
            }
        }

        public void ChangeVehicleStatus(string i_VehicleLicenseNumberStr, eVehicleGarageStatus i_VehicleGarageStatus)
        {
            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    vehicle.VehicleInformation.VehicleGarageStatus = i_VehicleGarageStatus;
                }
            }
        }

        public List<string> GetAllVehicleLicenseNumbersInGarage()
        {
            List<string> allVehicleLicenseNumbers = new List<string>();

            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                allVehicleLicenseNumbers.Add(vehicle.VehicleLicenseNumber);
            }

            return allVehicleLicenseNumbers;
        }

        public List<string> GetAllVehicleLicenseNumbersInGarageFilteredByStatus(eVehicleGarageStatus i_VehicleGarageStatus)
        {
            List<string> filteredVehicleLicenseNumbers = new List<string>();

            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleInformation.VehicleGarageStatus == i_VehicleGarageStatus)
                {
                    filteredVehicleLicenseNumbers.Add(vehicle.VehicleLicenseNumber);
                }
            }

            return filteredVehicleLicenseNumbers;
        }

        public void ShowAllDetailsOfCar(string i_VehicleLicenseNumberStr)
        {
            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
        }

        public void MaxWhellsInflator(string i_VehicleLicenseNumberStr)
        {
            foreach (Vehicle vehicle in this.VehicleObjectsCollection)
            {
                if (vehicle.VehicleLicenseNumber == i_VehicleLicenseNumberStr)
                {
                    for (int i = 0; i < vehicle.VehicleWheelsArray.Length; i++)
                    {
                        if (vehicle.VehicleWheelsArray[i].CurrentAirPressure < vehicle.VehicleWheelsArray[i].MaxAirPressureByManufacturer)
                        {
                            vehicle.VehicleWheelsArray[i].MaxPressureWheelsInflator(
                                vehicle.VehicleWheelsArray[i].MaxAirPressureByManufacturer - vehicle.VehicleWheelsArray[i].CurrentAirPressure);
                        }
                    }
                }
            }
        }

        public void CheckBatteryTimeLeftInHoursUserInput(float i_BatteryTimeLeftInHours)
        {
            ElectricVehicle electricVehicle = m_Vehicle as ElectricVehicle;

            if (electricVehicle != null)
            {
                if (i_BatteryTimeLeftInHours > electricVehicle.MaxBatteryLifeTimeInHours)
                {
                    throw new ValueOutOfRangeException(0.0f, electricVehicle.MaxBatteryLifeTimeInHours, "amount of time to charge is higher then maximum"); 
                }
            }
        }

        public void CheckCurrentAmontOfFuelInLitersUserInput(float i_CurrentAmontOfFuelInLiters)
        {
            RegularFuelVehicle regularFuelVehicle = m_Vehicle as RegularFuelVehicle;

            if (regularFuelVehicle != null)
            {
                if (i_CurrentAmontOfFuelInLiters > regularFuelVehicle.MaxAmountOfFuelInLiters)
                {
                    throw new ValueOutOfRangeException(0.0f, regularFuelVehicle.MaxAmountOfFuelInLiters, "amount of fuel to add is higher then maximum");
                }
            }
        } 
    }
}
