using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private readonly Wheel[] m_Wheels;
       
        public Vehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels)
        {
            r_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber; 
            m_Wheels = i_Wheels;
        }
        
        public string LicencseNumber
        {
            get { return r_LicenseNumber; }
        }
      
        public Wheel[] Wheels
        {
            get { return m_Wheels; }
        }
        
        public virtual void AddEnergy(float i_Amount) {}


        public virtual string GetEngineTypeDetails()
        {
            return string.Empty;
        }
        
        public virtual Enums.EnergyType GetEnergyType
        {
            get
            {
                return Enums.EnergyType.Defualt;
            }
        }

        public virtual float GetMaxEngineCapacity
        {
            get
            {
                return float.NaN;
            }
        }

        public virtual float GetCurrentEngineCapacity
        {
            get
            {
                return float.NaN;
            }
        }

        public override string ToString()
        {
            StringBuilder toPrint = new StringBuilder();
            toPrint.AppendLine(string.Format("License number:{0}", r_LicenseNumber));
            toPrint.AppendLine(string.Format("Model name: {0}", r_ModelName));
            toPrint.AppendLine(string.Format("Wheels:"));
            foreach (Wheel wheel in m_Wheels)
            {
                toPrint.AppendLine(wheel.ToString());
            }

            toPrint.AppendLine(GetEngineTypeDetails());
            return toPrint.ToString();
        }

    }
}
