using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class RegularFuelVehicle : Vehicle
    {
        private float m_CurrentAmontOfFuelInLiters;
        private float m_MaxAmountOfFuelInLiters;
        private eFuelTypes m_FuelType;                

        public RegularFuelVehicle()
        {            
        }

        protected internal float MaxAmountOfFuelInLiters 
        {
            get { return this.m_MaxAmountOfFuelInLiters; }
            set { this.m_MaxAmountOfFuelInLiters = value; }
        }

        protected internal float CurrentAmontOfFuelInLiters 
        {
            get { return this.m_CurrentAmontOfFuelInLiters; }
            set { this.m_CurrentAmontOfFuelInLiters = value; }
        }

        public eFuelTypes FuelType
        {
            get { return this.m_FuelType; }
            set { this.m_FuelType = value; }
        }

        /// <summary>
        /// this method will refill the fuel
        /// </summary>
        /// <exception cref="ValueOutOfRangeException">Thrown when the value is too high or when its not zero and above</exception>
        /// <exception cref="ArgumentException">Thrown when the fuel type for riffil is wrong</exception>
        /// <param name="i_FuelAmoutToAddInLiters">Used to indicate fuel amount to add in liters</param>
        /// <param name="i_FuelType">Used to indicate fuel type</param>
        protected internal void FuelRefill(float i_FuelAmoutToAddInLiters, eFuelTypes i_FuelType)
        {            
            float fuelAmountRatio = this.MaxAmountOfFuelInLiters - this.CurrentAmontOfFuelInLiters;

            if (i_FuelAmoutToAddInLiters >= 0)
            {
                if (i_FuelType == this.FuelType)
                {
                    if (i_FuelAmoutToAddInLiters < this.MaxAmountOfFuelInLiters)
                    {
                        this.CurrentAmontOfFuelInLiters += i_FuelAmoutToAddInLiters;
                        LeftPercentageEnergySource = (this.CurrentAmontOfFuelInLiters / this.MaxAmountOfFuelInLiters) * 100;
                    }
                    else
                    {                        
                        throw new ValueOutOfRangeException(0.0f, fuelAmountRatio, "fuel amount to add is too high");
                    }
                }
                else
                {                    
                    throw new ArgumentException("The fuel type for riffil is wrong");
                }
            }
            else
            {                
                throw new ValueOutOfRangeException(0.0f, fuelAmountRatio, "fuel amount to add have to be zero and above");
            }           
        }

        /// <summary>
        /// This method collects a general part of information on an regular fuel vehicle
        /// </summary>
        /// <returns>string with regular fuel info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine();
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine();
            stringBuilder.Append("Max Amount Of Fuel In Liters: ");
            stringBuilder.AppendLine(this.MaxAmountOfFuelInLiters.ToString());
            stringBuilder.Append("CurrentAmontOfFuelInLiters: ");
            stringBuilder.AppendLine(this.CurrentAmontOfFuelInLiters.ToString());
            stringBuilder.Append("Fuel Type: ");
            stringBuilder.AppendLine(this.FuelType.ToString());

            return stringBuilder.ToString();
        }
    }
}
