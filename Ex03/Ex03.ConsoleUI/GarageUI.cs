using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GargeUI
    {
        private static Garage s_Garage;

        public static void RunGarage()
        {
            s_Garage = new Garage();
            while (true)
            {
                startProgram();
                break;
            }

        }

        private static void startProgram()
        {
            bool programRuns = true;
            int option;
            StringBuilder chooseOption;
            while (programRuns)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                chooseOption = new StringBuilder();
                string newLine = Environment.NewLine;
                chooseOption.AppendLine();
                chooseOption.AppendLine("Please choose one of those Actions by number:");
                chooseOption.AppendLine("1) Enter a new vehicle to the Garage");
                chooseOption.AppendLine("2) Show all vehicles in the Garage");
                chooseOption.AppendLine("3) Change vehicle statues");
                chooseOption.AppendLine("4) Add air to a vehicles wheels");
                chooseOption.AppendLine("5) Refuel / charge a the vehicle");
                chooseOption.AppendLine("6) Show details of a vehicle");
                chooseOption.AppendLine("7) Exit the program");
                Console.Write(chooseOption.ToString());
                string strOp = Console.ReadLine();
                if (int.TryParse(strOp, out option))
                {
                    switch (option)
                    {
                        case 1:
                            Ex02.ConsoleUtils.Screen.Clear();
                            AddNewClientVehicle();
                            break;

                        case 2:
                            Ex02.ConsoleUtils.Screen.Clear();
                            showAllVehicleAndCurrentStatus();
                            break;

                        case 3:
                            Ex02.ConsoleUtils.Screen.Clear();
                            changeVehicleStatus();
                            break;

                        case 4:
                            Ex02.ConsoleUtils.Screen.Clear();
                            AddAirToWheels();
                            break;

                        case 5:
                            Ex02.ConsoleUtils.Screen.Clear();
                            AddEnergyToCar();
                            break;

                        case 6:
                            Ex02.ConsoleUtils.Screen.Clear();
                            PrintCarDetails();
                            break;

                        case 7:
                            Ex02.ConsoleUtils.Screen.Clear();
                            programRuns = false;
                            break;

                    }

                    if (option <= 0 || option > 8)
                    {
                        Ex02.ConsoleUtils.Screen.Clear();
                        Console.WriteLine(String.Format("Invalid input, please try again{0}", newLine));
                    }

                }
            }

            Console.WriteLine("Thanks And Good Bye");
            Console.WriteLine("Press eneter to exit..");
            Console.ReadLine();
        }

        private static void AddNewClientVehicle()
        {
            Console.WriteLine("Please enter the license plate number");
            string newLicenseNumber = Console.ReadLine();
            if (s_Garage.VehicleExists(newLicenseNumber))
            {
                Console.WriteLine("This license plate number already exist! transferring to underRepair");
                s_Garage.ChangeStatus(newLicenseNumber, Enums.Status.UnderRepair);
            }

            else
            {
                Vehicle newVehicle = createVehicle(newLicenseNumber);
                Client newClient = createClient(newVehicle);
                s_Garage.AddNewClient(newClient, newVehicle);
            }

        }
    
        private static Vehicle createVehicle(string i_NewLicenseNumber)
        {
            Vehicle vehicle;
            string licenseNumber = UserInputValidator.GetLicensePlate(i_NewLicenseNumber);
            Enums.VehicleType modelName = UserInputValidator.GetModelNameInput();
            vehicle = Factory.GetInstansOf(licenseNumber, modelName);  
            return vehicle;
        }

        private static Client createClient(Vehicle i_Vehicle)
        {
            Console.WriteLine("Please input the clients name");
            string newClientName = UserInputValidator.GetValidName(Console.ReadLine());
            Console.WriteLine("Please input the client phone number ");
            string newPhoneNumber = UserInputValidator.CreatePhoneNumber(Console.ReadLine());
            return new Client(newClientName, newPhoneNumber, i_Vehicle);
        }

        private static void showAllVehicleAndCurrentStatus()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Enums.Status statusFilter = UserInputValidator.GetStatusFilter();
            List<string> AllGarageLicensePlates;
            
            if ( statusFilter == Enums.Status.Defualt)
            {
                Console.WriteLine("All the Vehicle number plates in the Garage:");
                AllGarageLicensePlates = s_Garage.GetAllLicensNumbersInGarage();
                
            }

            else
            {
                Console.WriteLine(string.Format("All the {0} Vehicle number plates in the Garage", statusFilter));
                AllGarageLicensePlates = s_Garage.GetAllLicensNumbersInGarage(statusFilter);
            }

            foreach (string GarageLicensePlate in AllGarageLicensePlates)
            {
                Console.WriteLine(GarageLicensePlate);
            }
            Console.WriteLine("Press Enter to continue..");
            Console.ReadLine();
        }

        private static void changeVehicleStatus()
        {
            Console.WriteLine("Please enter the vehicle license plate number:");
            string licensePlateNumber = Console.ReadLine();
            UserInputValidator.GetLicensePlate(licensePlateNumber);

            if (s_Garage.VehicleExists(licensePlateNumber))
            {
                
                Console.WriteLine(string.Format("The current status of vehicle {0} is: {1}", licensePlateNumber, s_Garage.GetClient(licensePlateNumber).Status));
                Enums.Status carStatus = UserInputValidator.VaildStatus();
                s_Garage.ChangeStatus(licensePlateNumber, carStatus);
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Vehicle status change successfully.");
            }

            else
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("The vehicle isn't in the Garage");
            }

            Console.WriteLine("Press eneter to continue..");
            Console.ReadLine();
        }

        private static void AddAirToWheels()
        {
            Console.WriteLine("Please enter the vehicle license number");
            string carLicense = Console.ReadLine();
            if (s_Garage.VehicleExists(carLicense))
            {
                Ex02.ConsoleUtils.Screen.Clear();
                s_Garage.FillAirPressureToMax(carLicense);
                Console.WriteLine("AirPressuer set to max");
            }

            else
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("The vehicle isn't in the Garage");
            }

            Console.WriteLine("Press eneter to continue..");
            Console.ReadLine();
        }

        private static void AddEnergyToCar()
        {
            string carLicense = string.Empty;
            while (!s_Garage.VehicleExists(carLicense))
            {
                Console.WriteLine("Please enter the vehicle license number");
                carLicense = UserInputValidator.GetLicensePlate(Console.ReadLine());
            }

            Enums.EnergyType energyType = Enums.EnergyType.Defualt;
            while (!energyType.Equals(s_Garage.GetEnergyType(carLicense)))
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine(string.Format("Yor energy type is: {0}", s_Garage.GetEnergyType(carLicense)));
                energyType = UserInputValidator.GetEngineType();
            }
            
            Console.WriteLine("Please enter the amount you would like to add");
            float amountToAdd = UserInputValidator.GetEnergyAmount(Console.ReadLine());
            while (!isValidAmount(amountToAdd, carLicense))
            {
                Console.WriteLine(string.Format("The Current amount is: {0} , the max is: {1}", s_Garage.GetCurrnetVehicleEnergyCapacity(carLicense), s_Garage.GetMaxVehicleEnergyCapacity(carLicense)));
                amountToAdd = UserInputValidator.GetEnergyAmount(Console.ReadLine());
                break;
            }

            s_Garage.SetEneryAmount(carLicense,energyType, amountToAdd);
            Console.WriteLine(string.Format("Success,the current amount is: {0}",s_Garage.GetCurrnetVehicleEnergyCapacity(carLicense)));
            Console.WriteLine("Press any enter to continue..");
            Console.ReadLine();
        }

        private static bool isValidAmount(float amountToAdd, string i_License)
        {
            bool isValid = true;
            float tryToAdd = amountToAdd + s_Garage.GetCurrnetVehicleEnergyCapacity(i_License);
            if (amountToAdd > s_Garage.GetMaxVehicleEnergyCapacity(i_License) || (tryToAdd > s_Garage.GetMaxVehicleEnergyCapacity(i_License)) || amountToAdd < 0)
            {
                isValid = false;
            }
            
            return isValid;
        }

        private static void PrintCarDetails()
        {

            Ex02.ConsoleUtils.Screen.Clear();
            string carLicense = string.Empty;
            while (!s_Garage.VehicleExists(carLicense))
            {
                Console.WriteLine("Please enter the vehicle license number");
                carLicense = UserInputValidator.GetLicensePlate(Console.ReadLine());
            }

            Client client = s_Garage.GetClient(carLicense);
            Console.WriteLine(s_Garage.ToString(client));
            Console.WriteLine("Press Enter to continue..");
            Console.ReadLine();
        }
    }
}

