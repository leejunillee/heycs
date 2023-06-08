using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngineEnergy : EngineEnergy
    {
        private readonly Enums.EnergyType r_EnergyType;
        public ElectricEngineEnergy(float i_BatteryMaxPower, Enums.EnergyType i_EnergyType, float i_EnergyPrecentage) : base(i_BatteryMaxPower, i_EnergyPrecentage)
        {
            r_EnergyType = i_EnergyType;
        }
  
        public void ChargeBattery(float i_Hours)
        {
            base.AddEnergy(i_Hours);
        }

        public override Enums.EnergyType GetEnergyType()
        {
            return r_EnergyType;
        }

        public override string ToString()
        {
            return string.Format("Electric engine, Currnet amount: {0},  Max power amount: {1}",base.CurrentEnergyState, base.MaxCapacity);
        }

    }
}