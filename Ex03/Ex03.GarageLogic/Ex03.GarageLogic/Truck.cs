using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_MaxCargoCapacity;
        private readonly EngineEnergy r_EngineEnergy;
        private bool m_HazardousMaterials;

        public Truck(string i_ModelName, string i_LicenseNumber, float i_EnergyPrecentage, Wheel[] i_Wheels, Enums.EnergyType i_EnergyType, bool i_HazardousMaterials, float i_MaxCargoCapacity, float i_MaxEnergy)
            :  base(i_ModelName, i_LicenseNumber, i_Wheels)
        {
            if (i_EnergyType == Enums.EnergyType.Electric)
            {
                throw new ArgumentException("Truck do not support electric engine");
            }

            r_EngineEnergy = new FuelEngineEnergy(i_MaxEnergy, i_EnergyType, i_EnergyPrecentage);
            r_MaxCargoCapacity = i_MaxCargoCapacity;
            m_HazardousMaterials = i_HazardousMaterials;
        }

        public bool AsHazardousMaterials
        {
            get
            {
                return m_HazardousMaterials;
            }

            set
            {
                m_HazardousMaterials = value;
            }
        }

        public override float GetMaxEngineCapacity
        {
            get
            {
                return r_EngineEnergy.MaxCapacity;
            }
        }

        public override Enums.EnergyType GetEnergyType
        {
            get
            {
                return r_EngineEnergy.GetEnergyType();
            }
        }

        public float MaxCargoCapacity
        {
            get
            {
                return r_MaxCargoCapacity;
            }
        }

        public override float GetCurrentEngineCapacity
        {
            get
            {
                return r_EngineEnergy.CurrentEnergyState;
            }

        }

        public override void AddEnergy(float i_Amount)
        {
            r_EngineEnergy.AddEnergy(i_Amount);
        }

        public override string GetEngineTypeDetails()
        {
            return string.Format("Truck, Carry hazardous materials: {0}, Maximum cargo capacity: {1}, Tank size: {2}L", m_HazardousMaterials, r_MaxCargoCapacity, r_EngineEnergy.MaxCapacity);
        }
    }
}
