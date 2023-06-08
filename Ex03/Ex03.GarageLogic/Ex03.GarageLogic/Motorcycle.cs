using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private readonly EngineEnergy r_EngineEnergy;
        private readonly int r_EngineCapacity;
        private Enums.MotorcycleLicenseType m_LicenseType;

        public Motorcycle(string i_ModelName, string i_LicenseNumber, float i_EnergyPrecentage, Wheel[] i_Wheels, Enums.EnergyType i_EnergyType, Enums.MotorcycleLicenseType i_LicenseType, int i_EngineCapacity, float i_MaxEnergy)
            : base(i_ModelName, i_LicenseNumber, i_Wheels)
        {
            if (i_EnergyType == Enums.EnergyType.Electric)
            {
                r_EngineEnergy = new ElectricEngineEnergy(i_MaxEnergy, i_EnergyType, i_EnergyPrecentage);
            }

            else
            {
                r_EngineEnergy = new FuelEngineEnergy(i_MaxEnergy, i_EnergyType, i_EnergyPrecentage);
            }

            m_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }
        public int EngineCapacity
        {
            get { return r_EngineCapacity; }
        }

        public Enums.MotorcycleLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public override void AddEnergy(float i_Amount)
        {
            r_EngineEnergy.AddEnergy(i_Amount);
        }

        public override float GetMaxEngineCapacity
        {
            get
            {
                return r_EngineEnergy.MaxCapacity;
            }
        }
        public override float GetCurrentEngineCapacity
        {
            get
            { 
                return r_EngineEnergy.CurrentEnergyState; 
            }

        }

        public override Enums.EnergyType GetEnergyType
        {
            get
            {
                return r_EngineEnergy.GetEnergyType();
            }
        }

        public override string GetEngineTypeDetails()
        {
            StringBuilder toPrint = new StringBuilder();
            if (r_EngineEnergy is FuelEngineEnergy fuelEngineEnergy)
            {
                toPrint.Append(String.Format("Motorcycle, License type: {0}, Engine capacity {1}", m_LicenseType, r_EngineCapacity));
                toPrint.Append(fuelEngineEnergy.ToString());
            }

            else
            {
                toPrint.Append(String.Format("Motorcycle, License type: {0}, Engine capacity: {1}", m_LicenseType, r_EngineCapacity));
                toPrint.Append(((ElectricEngineEnergy)r_EngineEnergy).ToString());
            }

            return toPrint.ToString(); ;
        }
     
    }
}
