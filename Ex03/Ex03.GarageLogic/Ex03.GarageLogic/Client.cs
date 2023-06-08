using System.Text;

namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private readonly Vehicle m_Vehicle;
        private Enums.Status m_Status;

        public Client(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_Status = Enums.Status.UnderRepair;
        }
       
        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public Enums.Status Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public override string ToString()
        {
            StringBuilder toPrint = new StringBuilder();   
            toPrint.AppendLine(string.Format("Owner name: {0}", m_OwnerName));
            toPrint.AppendLine(string.Format("Status of the vehicle: {0}", m_Status));
            toPrint.AppendLine(m_Vehicle.ToString());
            return toPrint.ToString();
        }
        
    }
}
