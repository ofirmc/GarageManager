using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    internal class GarageUI
    {
        private eVehicleType m_VehicleTypeUserInput;
        private eCarColor m_ColorUserInput;
        private eNumberOfDoors m_NumberOfDoorsUserInput;
        private eTwoWheeledVehicleLicenseType m_TwoWheeledVehicleLicenseType;
        private eVehicleGarageStatus m_VehicleGarageStatusUserInput;
        private eTransferringDangereusMaterials m_TransferringDangereusMaterials;
        private GarageManager m_GarageManager = new GarageManager();
        private bool m_ExitApplication = true;

        public enum eMainMenuOptions
        {
            AddNewVehicle = 1,
            showLiceneNumbersOfVehiclesInTheGarage,
            changeVehicleStatus,
            inflateWheelsToMax,
            refillRegualrVehicle,
            rechargeElectricVehicle,
            showFullVehicleDetails,
            exitApplication
        }

        public enum eThirdLevelBaseClassTypes
        {
            ElectricAutomobile,
            ElectricTwoWheeledVehicle,
            CommercialFuelAutomobile,
            RegularFualTwoWheeledVehicle,
            RegularFuelAutomobile
        }

        public GarageUI()
        {
        }

        public bool ExitApplication
        {
            get { return m_ExitApplication; }
            set { m_ExitApplication = value; }
        }

        private void MenuOptionsExecute()
        {
            bool isValidMenuOptionInput = true;

            do
            {
                try
                {
                    Console.WriteLine(@"
Menu
====
1. Insert a new car
2. Show licene numbers of vehicles in the garage
3. Change a vehicle status
4. Inflate wheels air of a car to maximun
5. Refill a regular(gasoline) vehicle
6. Recharge electric vehicle
7 .Show full vehicle details
8. Exit");

                    string menuOptionsStr = Console.ReadLine();
                    isValidMenuOptionInput = true;

                    eMainMenuOptions menuOptions = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), menuOptionsStr);

                    switch (menuOptions)
                    {
                        case eMainMenuOptions.AddNewVehicle:
                            NewVehicleBasicInfoCollect();
                            break;
                        case eMainMenuOptions.showLiceneNumbersOfVehiclesInTheGarage:
                            GetVehicleLicenseNumbersInGarage();
                            break;
                        case eMainMenuOptions.changeVehicleStatus:
                            ChangeVehicleStatus();
                            break;
                        case eMainMenuOptions.inflateWheelsToMax:
                            MaxWhellsInflate();
                            break;
                        case eMainMenuOptions.refillRegualrVehicle:
                            RefillFuelVehicle();
                            break;
                        case eMainMenuOptions.rechargeElectricVehicle:
                            RechargeElectricVehicleBattery();
                            break;
                        case eMainMenuOptions.showFullVehicleDetails:
                            ShowAllVehicleData();
                            break;
                        case eMainMenuOptions.exitApplication:
                            this.ExitApplication = false;
                            break;
                        default:
                            isValidMenuOptionInput = false;
                            PrintErrorWithColor("Invalid menu option input. choose a correct number again");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuOptionInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuOptionInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidMenuOptionInput);
        }

        private void ShowAllVehicleData()
        {
            string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

            if (!m_GarageManager.CarExist(i_VehicleLicenseNumberStr))
            {
                m_GarageManager.ShowAllDetailsOfCar(i_VehicleLicenseNumberStr);
            }
            else
            {
                PrintErrorWithColor("Vehicle is not in the garage");
            }
        }

        private void GetVehicleLicenseNumbersInGarage()
        {
            bool isValidMenuOptionInput = true;
            List<string> licenseNumbersListStr = null;

            do
            {
                try
                {
                    Console.WriteLine(
    @"Vehicle License Numbers: Please choose an option from the menu
Menu
====
1. Show all vehicle license numbers in the garage by InRepair status
2. Show all vehicle license numbers in the garage by Repaired status
3. Show all vehicle license numbers in the garage by Paid status
4. Show all vehicle license numbers in the garage");

                    string statusMenuOptionsStr = Console.ReadLine();

                    if (statusMenuOptionsStr == "4")
                    {
                        Console.WriteLine(
        @"All licenses:
=============");

                        licenseNumbersListStr = m_GarageManager.GetAllVehicleLicenseNumbersInGarage();
                    }
                    else
                    {
                        eVehicleGarageStatus menuOptions = (eVehicleGarageStatus)Enum.Parse(typeof(eVehicleGarageStatus), statusMenuOptionsStr);

                        switch (menuOptions)
                        {
                            case eVehicleGarageStatus.InRepair:
                                Console.WriteLine(
    @"All licenses filtered by InRepair status:
==========================================");
                                licenseNumbersListStr = m_GarageManager.GetAllVehicleLicenseNumbersInGarageFilteredByStatus(eVehicleGarageStatus.InRepair);
                                isValidMenuOptionInput = true;
                                break;
                            case eVehicleGarageStatus.Repaired:
                                Console.WriteLine(
    @"All licenses filtered by Repaired status:
==========================================");
                                licenseNumbersListStr = m_GarageManager.GetAllVehicleLicenseNumbersInGarageFilteredByStatus(eVehicleGarageStatus.Repaired);
                                isValidMenuOptionInput = true;
                                break;
                            case eVehicleGarageStatus.Paid:
                                Console.WriteLine(
    @"All licenses filtered by Paid status:
==========================================");
                                licenseNumbersListStr = m_GarageManager.GetAllVehicleLicenseNumbersInGarageFilteredByStatus(eVehicleGarageStatus.Paid);
                                isValidMenuOptionInput = true;
                                break;
                            default:
                                isValidMenuOptionInput = false;
                                PrintErrorWithColor("Invalid menu option input. choose a correct number again");
                                break;
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuOptionInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuOptionInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidMenuOptionInput);

            foreach (string licenseNumberStr in licenseNumbersListStr)
            {
                Console.WriteLine(licenseNumberStr);
            }
        }

        private void MaxWhellsInflate()
        {
            try
            {
                string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

                if (!m_GarageManager.CarExist(i_VehicleLicenseNumberStr))
                {
                    m_GarageManager.MaxWhellsInflator(i_VehicleLicenseNumberStr);
                    Console.WriteLine("All whells where inflated to maximum");
                }
                else
                {
                    PrintErrorWithColor("Vehicle is not in the garage");
                }
            }
            catch (ValueOutOfRangeException ex)
            {
                PrintErrorWithColor(ex.Message);
            }
            catch (ArgumentException ex)
            {
                PrintErrorWithColor(ex.Message);
            }
            catch (Exception ex)
            {
                PrintErrorWithColor(ex.Message);
            }
        }

        private void NewVehicleBasicInfoCollect()
        {
            string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

            if (!m_GarageManager.CheckCarExistInRepairFallback(i_VehicleLicenseNumberStr))
            {
                Console.WriteLine("vehicle is already in the garage. The system is changing this car status to \"In Repair\"");
            }
            else
            {
                GetVehicleType();
                string vehicleModelNameStr = GetVehicleModelName();
                NewVehicleInsert(i_VehicleLicenseNumberStr, vehicleModelNameStr, m_VehicleTypeUserInput);
            }
        }

        private string GetUserStringInput(string i_MessageToPrint)
        {
            bool validInput = true;
            string userInputStr = string.Empty;

            do
            {
                Console.Write(i_MessageToPrint);
                userInputStr = Console.ReadLine();

                if (userInputStr == string.Empty)
                {
                    validInput = false;
                    PrintErrorWithColor("Invalid input");
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return userInputStr;
        }

        private string GetVehicleModelName()
        {
            return GetUserStringInput("Please enter the vehicle model name: ");
        }

        private string GetVehicleLicenseNumber()
        {
            return GetUserStringInput("Please enter the Vehicle License Number: ");
        }

        private string GetVehicleOwnerName()
        {
            return GetUserStringInput("Please enter the vehicle owner name: ");
        }

        private string GetVehicleOwnerPhone()
        {
            return GetUserStringInput("Please enter the vehicle owner phone number: ");
        }

        private void NewVehicleInsert(string i_VehicleLicenseNumberStr, string i_VehicleModelNameStr, eVehicleType i_VehicleType)
        {
            float i_BatteryTimeLeftInHours = 0;
            float i_CurrentAmontOfFuelInLiters = 0;
            int i_TwoWheeledVehicleEngineCC = 0;
            float capacityInCubicMeter = 0;
            bool IsTransferringDangereusMaterials = true;

            Type baseClassType = m_GarageManager.NewVehicleCreate(i_VehicleType);
            eThirdLevelBaseClassTypes ThirdLevelBaseClassTypes = (eThirdLevelBaseClassTypes)Enum.Parse(typeof(eThirdLevelBaseClassTypes), baseClassType.Name);

            switch (ThirdLevelBaseClassTypes)
            {
                case eThirdLevelBaseClassTypes.ElectricAutomobile:
                    i_BatteryTimeLeftInHours = GetBatteryTimeLeftInHours();
                    CarColorChoose();
                    NumberOfDoorsChoose();
                    break;
                case eThirdLevelBaseClassTypes.ElectricTwoWheeledVehicle:
                    i_BatteryTimeLeftInHours = GetBatteryTimeLeftInHours();
                    i_TwoWheeledVehicleEngineCC = GetTwoWheeledVehicleEngineCC();
                    GetTwoWheeledVehicleLicenseType();
                    break;
                case eThirdLevelBaseClassTypes.CommercialFuelAutomobile:
                    i_CurrentAmontOfFuelInLiters = GetCurrentAmontOfFuelInLiters();
                    capacityInCubicMeter = GetCapacityInCubicMeter();
                    IsTransferringDangereusMaterials = GetIsTransferringDangereusMaterials();
                    break;
                case eThirdLevelBaseClassTypes.RegularFualTwoWheeledVehicle:
                    i_CurrentAmontOfFuelInLiters = GetCurrentAmontOfFuelInLiters();
                    i_TwoWheeledVehicleEngineCC = GetTwoWheeledVehicleEngineCC();
                    GetTwoWheeledVehicleLicenseType();
                    break;
                case eThirdLevelBaseClassTypes.RegularFuelAutomobile:
                    i_CurrentAmontOfFuelInLiters = GetCurrentAmontOfFuelInLiters();
                    CarColorChoose();
                    NumberOfDoorsChoose();
                    break;
                default:
                    break;
            }

            m_GarageManager.NewVehicleInsert(
                i_VehicleLicenseNumberStr,
                i_VehicleModelNameStr,
                m_ColorUserInput,
                m_NumberOfDoorsUserInput,
                GetVehicleOwnerName(),
                GetVehicleOwnerPhone(),
                i_BatteryTimeLeftInHours,
                i_CurrentAmontOfFuelInLiters,
                i_TwoWheeledVehicleEngineCC,
                m_TwoWheeledVehicleLicenseType,
                capacityInCubicMeter,
                IsTransferringDangereusMaterials);

            int i_NumberOfWheels = m_GarageManager.NumberOfWheels;
            m_GarageManager.WheelsCollection = WheelsInsert(i_NumberOfWheels);

            m_GarageManager.InsertToVehicleObjectsCollection();
        }

        private bool GetIsTransferringDangereusMaterials()
        {
            bool isValidMenuInput = true;
            bool transferringDangereusMaterials = true;

            do
            {
                try
                {
                    m_TransferringDangereusMaterials = (eTransferringDangereusMaterials)ParseAnyEnumUserInput(
@"Please enter If Transferring Dangereus Materials by choosing a number from the 
menu:
1. Yes
2. No",
typeof(eTransferringDangereusMaterials));

                    isValidMenuInput = Enum.IsDefined(typeof(eTransferringDangereusMaterials), m_TransferringDangereusMaterials);

                    switch (m_TransferringDangereusMaterials)
                    {
                        case eTransferringDangereusMaterials.Yes:
                            transferringDangereusMaterials = true;
                            break;
                        case eTransferringDangereusMaterials.No:
                            transferringDangereusMaterials = false;
                            break;
                        default:
                            isValidMenuInput = false;
                            break;
                    }

                    if (!isValidMenuInput)
                    {
                        PrintErrorWithColor("Invalid number choice");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidMenuInput);

            return transferringDangereusMaterials;
        }

        private float GetCapacityInCubicMeter()
        {
            return GetUserFloatInput("Please enter the Capacity In Cubic Meter: ");
        }

        private int GetTwoWheeledVehicleEngineCC()
        {
            return GetUserIntInput("Please enter the engine cc in whole number: ");
        }

        private void RechargeElectricVehicleBattery()
        {
            bool isValidInput = true;

            do
            {
                try
                {
                    string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

                    if (!m_GarageManager.CarExist(i_VehicleLicenseNumberStr))
                    {
                        isValidInput = true;
                        m_GarageManager.RechargeElectricVehicleBattery(
                        i_VehicleLicenseNumberStr,
                        GetUserFloatInput("Please enter the amount of charge battery time to add: "));
                    }
                    else
                    {
                        PrintErrorWithColor("Vehicle is not in the garage");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidInput);
        }

        private void RefillFuelVehicle()
        {
            bool isValidInput = true;

            do
            {
                try
                {
                    eFuelTypes fuelType = (eFuelTypes)ParseAnyEnumUserInput(
@"Please enter the type of fuel by choosing a number from the menu:
1. Soler
2. Octan95
3. Octan96
4. Octan98",
typeof(eFuelTypes));

                    isValidInput = Enum.IsDefined(typeof(eFuelTypes), fuelType);

                    if (!isValidInput)
                    {
                        PrintErrorWithColor("Invalid fuel type input");
                    }
                    else
                    {
                        isValidInput = true;

                        string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

                        if (!m_GarageManager.CarExist(i_VehicleLicenseNumberStr))
                        {
                            m_GarageManager.RefillFuelVehicle(i_VehicleLicenseNumberStr, fuelType, GetUserFloatInput("Please enter the amount of fuel to add: "));
                        }
                        else
                        {
                            PrintErrorWithColor("Vehicle is not in the garage");
                        }
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidInput);
        }

        private void GetTwoWheeledVehicleLicenseType()
        {
            bool isValidMenuInput = true;

            do
            {
                try
                {
                    m_TwoWheeledVehicleLicenseType = (eTwoWheeledVehicleLicenseType)ParseAnyEnumUserInput(
@"Please enter the new Two Wheeled Vehicle License Type by choosing a number from the menu:
1. A
2. A1
3. AA
4. B1",
typeof(eTwoWheeledVehicleLicenseType));

                    isValidMenuInput = Enum.IsDefined(typeof(eTwoWheeledVehicleLicenseType), m_TwoWheeledVehicleLicenseType);
                    if (!isValidMenuInput)
                    {
                        PrintErrorWithColor("Invalid license type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidMenuInput);
        }

        private void ChangeVehicleStatus()
        {
            string i_VehicleLicenseNumberStr = GetVehicleLicenseNumber();

            if (!m_GarageManager.CarExist(i_VehicleLicenseNumberStr))
            {
                GetVehicleGarageStatus();
                m_GarageManager.ChangeVehicleStatus(i_VehicleLicenseNumberStr, m_VehicleGarageStatusUserInput);
            }
            else
            {
                PrintErrorWithColor("Vehicle is not in the garage");
            }
        }

        private void GetVehicleGarageStatus()
        {
            bool isValidVehicleStatusMenuInput = true;

            do
            {
                try
                {
                    m_VehicleGarageStatusUserInput = (eVehicleGarageStatus)ParseAnyEnumUserInput(
@"Please enter the new vehicle garage status by choosing a number from the menu:
1. InRepair
2. Repaired
3. Paid",
typeof(eVehicleGarageStatus));

                    isValidVehicleStatusMenuInput = Enum.IsDefined(typeof(eVehicleGarageStatus), m_VehicleGarageStatusUserInput);
                    if (!isValidVehicleStatusMenuInput)
                    {
                        PrintErrorWithColor("Invalid vehicle type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidVehicleStatusMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidVehicleStatusMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidVehicleStatusMenuInput);
        }

        private void PrintErrorWithColor(string i_Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(i_Message);
            Console.ResetColor();
        }

        private void GetVehicleType()
        {
            bool isValidVehicleTypeMenuInput = true;

            do
            {
                try
                {
                    m_VehicleTypeUserInput = (eVehicleType)ParseAnyEnumUserInput(
@"Please enter the vehicle type by choosing a number from the menu:
1. Regulal(gasoline) motorcycle
2. Electric motorcycle
3. Regulal(gasoline) car
4. Electric car
5. Truck(gasoline)",
typeof(eVehicleType));

                    isValidVehicleTypeMenuInput = Enum.IsDefined(typeof(eVehicleType), m_VehicleTypeUserInput);
                    if (!isValidVehicleTypeMenuInput)
                    {
                        PrintErrorWithColor("Invalid vehicle type input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidVehicleTypeMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidVehicleTypeMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidVehicleTypeMenuInput);
        }

        private int GetUserIntInput(string i_MessageStr)
        {
            bool validInput = true;
            int o_ValueToReturn;
            string userInputStr = string.Empty;

            do
            {
                Console.Write(i_MessageStr);
                userInputStr = Console.ReadLine();

                bool isFloat = int.TryParse(userInputStr, out o_ValueToReturn);
                if (!isFloat)
                {
                    PrintErrorWithColor("Invalid input");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return o_ValueToReturn;
        }

        private float GetUserFloatInput(string i_MessageStr)
        {
            bool validInput = true;
            float o_ValueToReturn;
            string userInputStr = string.Empty;

            do
            {
                Console.Write(i_MessageStr);
                userInputStr = Console.ReadLine();

                bool isFloat = float.TryParse(userInputStr, out o_ValueToReturn);
                if (!isFloat)
                {
                    PrintErrorWithColor("Invalid input");
                    validInput = false;
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);

            return o_ValueToReturn;
        }

        private float GetCurrentAmontOfFuelInLiters()
        {
            bool isValidInput = true;
            float i_CurrentAmontOfFuelInLiters = 0;
            do
            {
                try
                {
                    isValidInput = true;
                    i_CurrentAmontOfFuelInLiters = GetUserFloatInput("Please enter the amount of current fuel in liters: ");

                    if (i_CurrentAmontOfFuelInLiters >= 0)
                    {
                        m_GarageManager.CheckCurrentAmontOfFuelInLitersUserInput(i_CurrentAmontOfFuelInLiters);
                    }
                    else
                    {
                        isValidInput = false;
                        PrintErrorWithColor("Input too low, must be 0 or above");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidInput);

            return i_CurrentAmontOfFuelInLiters;
        }

        private float GetBatteryTimeLeftInHours()
        {
            bool isValidInput = true;
            float i_BatteryTimeLeftInHours = 0;

            do
            {
                try
                {
                    isValidInput = true;
                    i_BatteryTimeLeftInHours = GetUserFloatInput("Please enter the amount of battery time left in hours: ");

                    if (i_BatteryTimeLeftInHours >= 0)
                    {
                        m_GarageManager.CheckBatteryTimeLeftInHoursUserInput(i_BatteryTimeLeftInHours);
                    }
                    else
                    {
                        isValidInput = false;
                        PrintErrorWithColor("Input too low, must be 0 or above");
                    }
                }
                catch (ValueOutOfRangeException ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidInput);

            return i_BatteryTimeLeftInHours;
        }

        private void NumberOfDoorsChoose()
        {
            bool isValidNumberOfDoorsMenuInput = true;

            do
            {
                try
                {
                    m_NumberOfDoorsUserInput = (eNumberOfDoors)ParseAnyEnumUserInput(
@"Please choose the number of doors from the menu:
2. Two
3. Three
4. Four
5. Five",
typeof(eNumberOfDoors));

                    isValidNumberOfDoorsMenuInput = Enum.IsDefined(typeof(eNumberOfDoors), m_NumberOfDoorsUserInput);
                    if (!isValidNumberOfDoorsMenuInput)
                    {
                        PrintErrorWithColor("Invalid number of doors input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidNumberOfDoorsMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidNumberOfDoorsMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidNumberOfDoorsMenuInput);
        }

        private object ParseAnyEnumUserInput(string i_MessageToPrint, Type target)
        {
            object enumUserInput = null;
            Console.WriteLine(i_MessageToPrint);
            string menuInputStr = Console.ReadLine();

            if (target.BaseType == typeof(Enum))
            {
                enumUserInput = Enum.Parse(target, menuInputStr);
            }

            return enumUserInput;
        }

        private void CarColorChoose()
        {
            bool isValidColorMenuInput = true;

            do
            {
                try
                {
                    m_ColorUserInput = (eCarColor)ParseAnyEnumUserInput(
@"Please choose the car color from the menu:
1. Red
2. Yellow
3. black
4. Silver",
typeof(eCarColor));

                    isValidColorMenuInput = Enum.IsDefined(typeof(eCarColor), m_ColorUserInput);
                    if (!isValidColorMenuInput)
                    {
                        PrintErrorWithColor("Invalid color input");
                    }
                }
                catch (ArgumentException ex)
                {
                    isValidColorMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
                catch (Exception ex)
                {
                    isValidColorMenuInput = false;
                    PrintErrorWithColor(ex.Message);
                }
            }
            while (!isValidColorMenuInput);
        }

        private Wheels[] WheelsInsert(int i_NumberOfWheels)
        {
            Wheels[] VehicleWheelsArray = new Wheels[i_NumberOfWheels];

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                VehicleWheelsArray[i] = new Wheels();
            }

            for (int i = 0; i < VehicleWheelsArray.Length; i++)
            {
                string manufacturerNameMessageStr = string.Format("{0} {1}{2}", "Please enter the manufacturer name for wheel number", (i + 1).ToString(), ":");
                string manufacturerName = GetUserStringInput(manufacturerNameMessageStr);

                float currentAirPressure = GetUserFloatInput("Please enter the current Air Pressure: ");

                float maxAirPressureByManufacturer = GetUserFloatInput("Please enter the Maximum Air Pressure By Manufacturer: ");

                VehicleWheelsArray[i].ManufacturerName = manufacturerName;
                VehicleWheelsArray[i].CurrentAirPressure = currentAirPressure;
                VehicleWheelsArray[i].MaxAirPressureByManufacturer = maxAirPressureByManufacturer;
            }

            return VehicleWheelsArray;
        }

        public void StartGarageApplication()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
@"Garage application managment
============================");
            Console.ResetColor();

            do
            {
                MenuOptionsExecute();
            }
            while (ExitApplication);
        }
    }
}