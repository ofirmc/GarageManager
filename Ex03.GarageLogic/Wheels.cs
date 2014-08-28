using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheels
    {
        private string m_ManufacturerName = string.Empty;
        private float m_CurrentAirPressure = 0;
        private float m_MaxAirPressureByManufacturer = 0;

        public Wheels()
        {
        }      

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure 
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressureByManufacturer 
        {
            get { return m_MaxAirPressureByManufacturer; }
            set { m_MaxAirPressureByManufacturer = value; }
        }

        public void WheelsDetailsCollector(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressureByManufacturer)
        {
            ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressureByManufacturer = i_MaxAirPressureByManufacturer;
        }
        
        /// <summary>
        /// Method for wheels inflate at maximum pressure
        /// </summary>
        /// <exception cref="ValueOutOfRangeException">Thrown when the value is too high or when its not zero and above</exception>
        /// <param name="i_AirAmountToAdd">Used to indicate air amount to add</param>
        public void MaxPressureWheelsInflator(float i_AirAmountToAdd)
        {
            if (i_AirAmountToAdd >= 0)
            {
                if (i_AirAmountToAdd + CurrentAirPressure <= MaxAirPressureByManufacturer)
                {
                    CurrentAirPressure += i_AirAmountToAdd;
                }
                else
                {
                    float airAmountRatio = MaxAirPressureByManufacturer - CurrentAirPressure;                                        
                    throw new ValueOutOfRangeException(0.0f, airAmountRatio, "Air amount to add is too high");
                }
            }
            else
            {
                throw new ValueOutOfRangeException(0.0f, i_AirAmountToAdd, "Air amount to add have to be zero and above");                
            }
        }
    }
}
