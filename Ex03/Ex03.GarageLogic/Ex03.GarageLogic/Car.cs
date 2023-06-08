using System.Threading.Tasks;
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private readonly Enums.CarNumberOfDoors r_CarDoorsNumber;
        private readonly EngineEnergy r_EngineEnergy;
        private Enums.CarColor m_CarColor;

        public Car(string i_ModelName, string i_LicenseNumber, float i_EnergyPrecentage, Wheel[] i_Wheels, Enums.EnergyType i_EnergyType, Enums.CarColor i_CarColor, Enums.CarNumberOfDoors i_CarNumDoors, float i_MaxEnergy)
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
            
            m_CarColor = i_CarColor;
            r_CarDoorsNumber = i_CarNumDoors;
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
                toPrint.Append(String.Format("Car, Color: {0}, Numbers of doors is: {1}, Tank size: {2}L", m_CarColor, r_CarDoorsNumber, r_EngineEnergy.MaxCapacity));
                toPrint.Append(fuelEngineEnergy.ToString());
            }

            else
            {
                toPrint.Append(String.Format("Car, Color: {0}, Numbers of doors is: {1}, Power size: {2}L", m_CarColor, r_CarDoorsNumber, r_EngineEnergy.MaxCapacity));
                toPrint.Append(((ElectricEngineEnergy)r_EngineEnergy).ToString());
            }

            return toPrint.ToString();
        }
    }
}
