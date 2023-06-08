
namespace Ex03.GarageLogic
{
    public class FuelEngineEnergy : EngineEnergy
    {
        private readonly Enums.EnergyType r_EnergyType;
        public FuelEngineEnergy(float i_FuelTankCapcity, Enums.EnergyType i_EnergyType, float i_EnergyPrecentage) :base(i_FuelTankCapcity, i_EnergyPrecentage)
        {
            r_EnergyType = i_EnergyType;   
        }

        public void AddFuel(float i_FuelAmount)
        {
            base.AddEnergy(i_FuelAmount);
        }

        public override Enums.EnergyType GetEnergyType()
        {
            return r_EnergyType;
        }

        public override string ToString()
        {
            return string.Format("Fuel type is: {0},Currnet amount: {1},  Max tank amount: {2}", r_EnergyType, base.CurrentEnergyState, base.MaxCapacity);
        }

    }
}