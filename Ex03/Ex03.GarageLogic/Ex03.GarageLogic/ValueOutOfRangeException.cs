using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const float m_MinValue = 0;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MaxValue) : base()
        {
            m_MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                return string.Format("Error occured, the minimal value is {0} and the maximal value is: {1}", m_MinValue,m_MaxValue);
                
            }
        }

    }    
}
