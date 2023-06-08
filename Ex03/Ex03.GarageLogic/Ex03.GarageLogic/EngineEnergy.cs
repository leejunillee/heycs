using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EngineEnergy
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergyState;

        public EngineEnergy(float i_MaxCapacity, float i_EnergyPrecentage)
        {
            r_MaxEnergy = i_MaxCapacity;
            m_CurrentEnergyState = i_EnergyPrecentage;
        }


        public float MaxCapacity
        {
            get { return r_MaxEnergy; }
        }

        public float CurrentEnergyState
        {
            get { return m_CurrentEnergyState; }
        }
        
        public void AddEnergy(float i_Amount)
        {
            if (isValidAmount(i_Amount))
            {
                m_CurrentEnergyState += i_Amount;
            }

            else
            {
                throw new ValueOutOfRangeException(r_MaxEnergy);
            }

        }

        private bool isValidAmount(float i_Amount)
        {
            bool checkAmount = false;
            if (i_Amount > 0 && i_Amount <= r_MaxEnergy)
            {
                float checkSum = i_Amount + m_CurrentEnergyState;
                if (checkSum <= r_MaxEnergy)
                {
                    checkAmount = true;
                }

            }

            return checkAmount;
        }

        public virtual Enums.EnergyType GetEnergyType()
        {
            return Enums.EnergyType.Defualt;
        }
    }
}