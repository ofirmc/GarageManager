using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_MessageStr)
            : base(i_MessageStr)
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public float MinimumValue 
        {
            get { return this.m_MinValue; }
            set { this.m_MinValue = value; }
        }

        public float MaximumValue 
        {
            get { return this.m_MaxValue; }
            set { this.m_MaxValue = value; }
        }
    }
}
