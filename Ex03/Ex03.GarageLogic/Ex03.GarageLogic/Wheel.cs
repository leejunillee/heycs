namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturyName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ManufacturyName, float i_AirPressure, float i_MaximalAirPressure)
        {
            r_ManufacturyName = i_ManufacturyName;
            m_CurrentAirPressure = i_AirPressure;
            r_MaxAirPressure = i_MaximalAirPressure;
        }

        public void AddAirPressure()
        {
              m_CurrentAirPressure = r_MaxAirPressure;
        }

        public Wheel DuplicateWheel()
        {
            return new Wheel(r_ManufacturyName, m_CurrentAirPressure,r_MaxAirPressure);
        }

        public override string ToString()
        {
            return string.Format("Manufactury Name Is: {0} , Air Pressure: {1}", r_ManufacturyName, m_CurrentAirPressure);
        }

    }
}
