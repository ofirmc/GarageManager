using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// enum for Fuel Types
    /// </summary>
    /// <remarks>Soler must always be defined to 1</remarks>
    public enum eFuelTypes
    {
        Soler = 1,
        Octan95,
        Octan96,
        Octan98
    }

    public enum eVehicleType
    {
        RegularMotorcycle = 1, ElectricMotorcycle, RegularCar, ElectricCar, Truck
    }

    /// <summary>
    /// enum for car color
    /// </summary>
    /// <remarks>Red must always be defined to 1</remarks>
    public enum eCarColor
    {
        Red = 1, Yellow, black, Silver
    }

    /// <summary>
    /// enum for number of door in the car
    /// </summary>
    /// <remarks>Two must always be defined to 2</remarks>
    public enum eNumberOfDoors
    {
        Two = 2, Three, Four, Five
    }

    /// <summary>
    /// enum for Two Wheeled Vehicle License Type
    /// </summary>
    /// <remarks>A must always be defined to 1</remarks>
    public enum eTwoWheeledVehicleLicenseType
    {
        A = 1, A1, AA, B1
    }

    /// <summary>
    /// enum for Vehicle Garage Status
    /// </summary>
    /// <remarks>InRepair must always be defined to 1</remarks>
    public enum eVehicleGarageStatus
    {
        InRepair = 1,
        Repaired,
        Paid
    }

    /// <summary>
    /// enum for Transferring Dangerous Materials
    /// </summary>
    /// <remarks>Yes must always be defined to 1</remarks>
    public enum eTransferringDangereusMaterials
    {
        Yes = 1, No
    }
}
