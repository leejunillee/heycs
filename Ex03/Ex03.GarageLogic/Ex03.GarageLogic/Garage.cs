using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<Client, Vehicle> r_LicensClientList;
        
        public Garage()
        {    
            r_LicensClientList = new Dictionary<Client,Vehicle>();
        }

        public void AddNewClient(Client i_NewClient, Vehicle i_NewVehicle)
        {
            if (VehicleExists(i_NewClient.Vehicle.LicencseNumber))
            {
                throw new ArgumentException("License number already exists");
            }

            r_LicensClientList[i_NewClient] = i_NewVehicle;
        }

        public bool VehicleExists(string i_Licenses)
        {
            bool vehicleExists = false;
            foreach (Vehicle vehicle in r_LicensClientList.Values)
            {
                if(vehicle.LicencseNumber.Equals(i_Licenses)) 
                { 
                    vehicleExists = true;
                    break;
                }

            }

            return vehicleExists;
        }
      
        
        public List<string> GetAllLicensNumbersInGarage()
        {
            List<string> licensWithMatchingStatus = new List<string>();
            foreach (Vehicle vehicle in r_LicensClientList.Values)
            {
              
                licensWithMatchingStatus.Add(vehicle.LicencseNumber);
                
            }

            return licensWithMatchingStatus;
        }
        public List<string> GetAllLicensNumbersInGarage(Enums.Status i_MatchStatus)
        {
            List<string> licensWithMatchingStatus = new List<string>();
            foreach (Client client in r_LicensClientList.Keys)
            {
                if (client.Status == i_MatchStatus)
                {
                    licensWithMatchingStatus.Add(r_LicensClientList[client].LicencseNumber);
                }

            }

            return licensWithMatchingStatus;

        }

        public void ChangeStatus(string i_License, Enums.Status i_Status)
        {
            Client client;
            if (!VehicleExists(i_License))
            {
                throw new ArgumentException("License number doesn't exists");
            }

            client = GetClient(i_License);
            client.Status = i_Status;
        }

        public void FillAirPressureToMax(string i_License)
        {
            Client client = GetClient(i_License);
            Wheel[] wheels = r_LicensClientList[client].Wheels;
            foreach (Wheel wheel in wheels)
            {
                wheel.AddAirPressure();
            }

        }
       
        public void SetEneryAmount(string i_License, Enums.EnergyType i_EnergyType, float i_Amount)
        {
            Client client = GetClient(i_License);
            if (!VehicleExists(i_License))
            {
                throw new ArgumentException("License number doesn't exists");
            }

            r_LicensClientList[client].AddEnergy(i_Amount);
        }

        public Vehicle GetVehicle(string i_License)
        {
            Client client = GetClient(i_License);
            return r_LicensClientList[client];
        }

        public Client GetClient(string i_License)
        {   
            Client client = GetVehicleExists(i_License);
            if (client == null)
            {
                throw new ArgumentException("License number doesn't exists");
            }
            
            return client;
        }
            
        public Enums.EnergyType GetEnergyType(string i_License)
        {
            Client client = GetClient(i_License);
            if (client == null)
            {
                throw new ArgumentException("License number doesn't exists");
            }

            return r_LicensClientList[client].GetEnergyType;
        }

        public float GetMaxVehicleEnergyCapacity(string i_License)
        {
            Client client = GetClient(i_License);
            if (client == null)
            {
                throw new ArgumentException("License number doesn't exists");
            }

            return r_LicensClientList[client].GetMaxEngineCapacity;
        }

        public float GetCurrnetVehicleEnergyCapacity(string i_License)
        {
            Client client = GetClient(i_License);
            if (client == null)
            {
                throw new ArgumentException("License number doesn't exists");
            }

            return r_LicensClientList[client].GetCurrentEngineCapacity;
        }

        private Client GetVehicleExists(string i_License)
        {
            Client clientFound = null;
            foreach (Client client in r_LicensClientList.Keys)
            {
                if (r_LicensClientList[client].LicencseNumber.Equals(i_License))
                {
                    clientFound = client;
                    break;
                }
            }
            return clientFound;
        }

        public string ToString(Client i_Client)
        {
            
            return r_LicensClientList[i_Client].ToString();
        }
    }
}
