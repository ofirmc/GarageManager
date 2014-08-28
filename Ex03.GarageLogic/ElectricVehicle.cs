using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class ElectricVehicle : Vehicle
    {
        private float m_BatteryTimeLeftInHours;
        private float m_MaxBatteryLifeTimeInHours;

        public ElectricVehicle()
        {            
        }        

        protected internal float BatteryTimeLeftInHours 
        {
            get { return this.m_BatteryTimeLeftInHours; }
            set { this.m_BatteryTimeLeftInHours = value; } 
        }

        protected internal float MaxBatteryLifeTimeInHours 
        {
            get { return this.m_MaxBatteryLifeTimeInHours; }
            set { this.m_MaxBatteryLifeTimeInHours = value; }
        }

        /// <summary>
        /// This method will charge the battery
        /// </summary>
        /// <exception cref="ValueOutOfRangeException">Thrown when the value is too high or when its not zero and above</exception>
        /// <param name="i_ChargeBatteryTimeToAdd">Used to indicate charge battery time to add</param>
        protected internal void RechargeBattery(float i_ChargeBatteryTimeToAdd)
        {           
            float ElectricityAmountRatio = this.MaxBatteryLifeTimeInHours - this.BatteryTimeLeftInHours;

            if (i_ChargeBatteryTimeToAdd >= 0)
            {
                if (i_ChargeBatteryTimeToAdd < this.MaxBatteryLifeTimeInHours && ElectricityAmountRatio > 0)
                {
                    this.BatteryTimeLeftInHours += i_ChargeBatteryTimeToAdd;
                    LeftPercentageEnergySource = (this.BatteryTimeLeftInHours / this.MaxBatteryLifeTimeInHours) * 100;
                }
                else
                {                    
                    throw new ValueOutOfRangeException(0.0f, ElectricityAmountRatio, "Charge amount of time to add is too high");
                }
            }
            else
            {                
                throw new ValueOutOfRangeException(0.0f, ElectricityAmountRatio, "Charge amount of time to add have to be zero and above");
            }            
        }

        /// <summary>
        /// This method collects a general part of information on an electric vehicle
        /// </summary>
        /// <returns>string with electric vehicle info parameters</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine();
            stringBuilder.Append("Hours left in battery before charge: ");
            stringBuilder.AppendLine(this.BatteryTimeLeftInHours.ToString());

            return stringBuilder.ToString();
        }
    }
}
