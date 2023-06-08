using Ex03.GarageLogic;
using System;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class UserInputValidator
    {
        public static string GetLicensePlate(string i_LicensePalte)
        {
            while (!checkLicensePlate(i_LicensePalte))
            {
                i_LicensePalte = Console.ReadLine();
            }

            return i_LicensePalte;
        }

        private static bool checkLicensePlate(string i_LicensePlate)
        {
            bool validPlateNumber = false;
            if (i_LicensePlate.Length == 7 || i_LicensePlate.Length == 8)
            {
                if (containOnlyDigits(i_LicensePlate))
                {
                    validPlateNumber = true;

                }

                else
                {
                    Console.WriteLine("License plate must contain only numbers. Try again");
                }

            }

            else
            {
                Console.WriteLine("The length most be 7-8 digits. Try again");
            }

            return validPlateNumber;
        }


        private static bool containOnlyDigits(string i_PlateNumber)
        {
            bool validPlateNumber = true;
            for (int i = 0; i < i_PlateNumber.Length && validPlateNumber; i++)
            {
                if (!Char.IsDigit(i_PlateNumber[i]))
                {
                    validPlateNumber = false;
                    break;
                }

            }

            return validPlateNumber;
        }


        public static Enums.VehicleType GetModelNameInput()
        {
            string model = string.Empty;
            while (!(model.Equals("1") || model.Equals("2") || model.Equals("3") || model.Equals("4") || model.Equals("5")))
            {
                Console.WriteLine("Please choose Engine type: 1.{0} 2.{1} 3.{2}",
                Enums.VehicleType.Car, Enums.VehicleType.Motorcyle, Enums.VehicleType.Truck);
                model = Console.ReadLine();
            }

            Enums.VehicleType modelType = Enums.VehicleType.Defualt;
            switch (model)
            {
                case "1":
                    modelType = Enums.VehicleType.Car;
                    break;

                case "2":
                    modelType = Enums.VehicleType.Motorcyle;
                    break;

                case "3":
                    modelType = Enums.VehicleType.Truck;
                    break;

            }

            return modelType;
        }

        public static string CreatePhoneNumber(string i_phoneNumer)
        {
            while (i_phoneNumer.Length != 10 || !stringIsMadeOfDigits(i_phoneNumer))
            {
                Console.WriteLine("please enter a phone number (contain only digit and the length is 10)");
                i_phoneNumer = Console.ReadLine();
            }

            return i_phoneNumer;
        }

        private static bool stringIsMadeOfDigits(string i_phoneNumber)
        {
            bool validPhoneNumber = true;
            foreach (char c in i_phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    validPhoneNumber = false;
                    break;
                }

            }

            return validPhoneNumber;
        }

        public static string GetValidName(string i_cleintName)
        {
            while (!containOnlyLetter(i_cleintName))
            {
                Console.WriteLine("Enter a valid name (contain only letters)");
                i_cleintName = Console.ReadLine();
            }

            return i_cleintName;
        }
    
        public static int GetWheelAmount(string i_Amount)
        {
            int wheelsAmount;
            while (!int.TryParse(i_Amount, out wheelsAmount) || wheelsAmount < 2 || wheelsAmount > 20)
            {
                Console.WriteLine("The min amount is 0 and the max is 20 , try again");
                i_Amount = Console.ReadLine();
            }

            return wheelsAmount;
        }

        public static string GetValidFactory(string i_Factory)
        {
            while (i_Factory.Length < 0 || i_Factory.Length > 20 || !containOnlyLetter(i_Factory))
            {
                Console.WriteLine("Please enter valid factory name, Max length is 20 contains only letters");
                i_Factory = Console.ReadLine();
            }

            return i_Factory;
        }

        private static bool containOnlyLetter(string i_PlateNumber)
        {
            bool validFactoryName = true;
            for (int i = 0; i < i_PlateNumber.Length && validFactoryName; i++)
            {
                if (Char.IsDigit(i_PlateNumber[i]))
                {
                    validFactoryName = false;
                    break;
                }
            }

            return validFactoryName;
        }

        public static float GetMaxAirPressure(string i_AirPressure)
        {
            float maxAirPressure;
            while (!float.TryParse(i_AirPressure, out maxAirPressure) || (maxAirPressure <= 0 || maxAirPressure > 1000))
            {
                Console.WriteLine("Invalid air pressure input please try again:");
                i_AirPressure = Console.ReadLine();
            }

            return maxAirPressure;
        }

        public static float GetCurrentAirPressure(string i_CurrentAirPressure, float i_MaxAirPressure)
        {
            float currentAirPressure;
            while (!float.TryParse(i_CurrentAirPressure, out currentAirPressure) || (currentAirPressure < 0 || currentAirPressure > i_MaxAirPressure))
            {
                Console.WriteLine(string.Format("Invalid air pressure input please try again the max is: {0}", i_MaxAirPressure));
                i_CurrentAirPressure = Console.ReadLine();
            }

            return currentAirPressure;
        }

        public static Enums.EnergyType GetEngineType()
        {
            string engineEnergy = string.Empty;
            while (!(engineEnergy.Equals("1") || engineEnergy.Equals("2") || engineEnergy.Equals("3") || engineEnergy.Equals("4") || engineEnergy.Equals("5")))
            {
                Console.WriteLine("Please choose Engine type: 1.{0} 2.{1} 3.{2} 4.{3} 5.{4}",
                Enums.EnergyType.Electric, Enums.EnergyType.Octan98, Enums.EnergyType.Octan96, Enums.EnergyType.Octan95, Enums.EnergyType.Soler);
                engineEnergy = Console.ReadLine();
            }

            Enums.EnergyType energyType = Enums.EnergyType.Defualt;
            switch (engineEnergy)
            {
                case "1":
                    energyType = Enums.EnergyType.Electric;
                    break;

                case "2":
                    energyType = Enums.EnergyType.Octan98;
                    break;

                case "3":
                    energyType = Enums.EnergyType.Octan96;
                    break;

                case "4":
                    energyType = Enums.EnergyType.Octan95;
                    break;

                case "5":
                    energyType = Enums.EnergyType.Soler;
                    break;
            }

            return energyType;
        }

        public static float GetMaxEnegineCapactiy()
        {
            float maxEngineCapacity;
            string amount = string.Empty;
            while (!float.TryParse(amount, out maxEngineCapacity) || maxEngineCapacity < 10 || maxEngineCapacity > 1000)
            {
                Console.WriteLine("Enter engine energy capacity , min 10 max 1000");
                amount = Console.ReadLine();
            }

            return maxEngineCapacity;
        }

        public static float GetEnergyPercentage(float i_MaxEngineCapacity)
        {
            float currentEngineCapacity;
            string amount = string.Empty;
            while (!float.TryParse(amount, out currentEngineCapacity) || currentEngineCapacity < 0 || currentEngineCapacity > i_MaxEngineCapacity)
            {
                Console.WriteLine(string.Format("Enter engine current amount of energy , min is: 10 and max is: {0}", i_MaxEngineCapacity));
                amount = Console.ReadLine();
            }

            return currentEngineCapacity;
        }

        public static Enums.CarColor GetCarColor()
        {
            string carColor = string.Empty;
            while (!(carColor.Equals("1") || carColor.Equals("2") || carColor.Equals("3") || carColor.Equals("4")))
            {
                Console.WriteLine(string.Format("Please choose car color: 1.{0} 2.{1} 3.{2} 4.{3}"
               , Enums.CarColor.White, Enums.CarColor.Gray, Enums.CarColor.Blue, Enums.CarColor.Black));
                 carColor = Console.ReadLine();
            }

            Enums.CarColor colorType = Enums.CarColor.Defualt;
            switch (carColor)
            {
                case "1":
                    colorType = Enums.CarColor.White;
                    break;

                case "2":
                    colorType = Enums.CarColor.Gray;
                    break;

                case "3":
                    colorType = Enums.CarColor.Blue;
                    break;

                case "4":
                    colorType = Enums.CarColor.Black;
                    break;

            }

            return colorType;
        }

        public static Enums.CarNumberOfDoors GetCarDoors()
        {

            string carNumDoors = string.Empty;
            while (!(carNumDoors.Equals("2") || carNumDoors.Equals("3") || carNumDoors.Equals("4") || carNumDoors.Equals("5")))
            {

                Console.WriteLine("Please choose number of doors to the car: 2 ,3 ,4 ,5");
                carNumDoors = Console.ReadLine();
            }

            Enums.CarNumberOfDoors numDoors = Enums.CarNumberOfDoors.Defualt;
            switch (carNumDoors)
            {
                case "2":
                    numDoors = Enums.CarNumberOfDoors.two;
                    break;

                case "3":
                    numDoors = Enums.CarNumberOfDoors.three;
                    break;

                case "4":
                    numDoors = Enums.CarNumberOfDoors.four;
                    break;

                case "5":
                    numDoors = Enums.CarNumberOfDoors.five;
                    break;

            }

            return numDoors;
        }

        public static Enums.MotorcycleLicenseType GetLicenseType()
        {
            string motorcycleLicens = string.Empty;
            while (!(motorcycleLicens.Equals("1") || motorcycleLicens.Equals("2") || motorcycleLicens.Equals("3") || motorcycleLicens.Equals("4")))
            {
                Console.WriteLine("Please choose license type: 1.{0} 2.{1} 3.{2} 4.{3}",
                Enums.MotorcycleLicenseType.AA, Enums.MotorcycleLicenseType.BB, Enums.MotorcycleLicenseType.B1, Enums.MotorcycleLicenseType.A);
                motorcycleLicens = Console.ReadLine();
            }

            Enums.MotorcycleLicenseType licensType = Enums.MotorcycleLicenseType.A;
            switch (motorcycleLicens)
            {
                case "1":
                    licensType = Enums.MotorcycleLicenseType.AA;
                    break;

                case "2":
                    licensType = Enums.MotorcycleLicenseType.BB;
                    break;

                case "3":
                    licensType = Enums.MotorcycleLicenseType.B1;
                    break;

            }
            return licensType;
        }

        public static int GetMotorcycleEngineCapacity()
        {

            int motorcycleCapacity;
            Console.WriteLine("Please enter engine capacity");
            string capacity = Console.ReadLine();
            while (!int.TryParse(capacity, out motorcycleCapacity) || (motorcycleCapacity < 50 || motorcycleCapacity > 1500))
            {
                Console.WriteLine("Please enter engine capacity , min is: 50 and max is: 1500");
                capacity = Console.ReadLine();
            }

            return motorcycleCapacity;
        }

        public static bool CarryMaterials()
        {
            bool carryHazard = false;
            Console.WriteLine("Please enter 1 if the truck has a carry hazard materials or press any other key if not");
            string key = Console.ReadLine();
            if (key.Equals("1"))
            {
                carryHazard = true;
            }

            return carryHazard;
        }

        public static float GetMaxCargo()
        {
            float maxCargo;
            string cargo = string.Empty;
            while (!float.TryParse(cargo, out maxCargo) || (maxCargo < 0 || maxCargo > 100000))
            {
                Console.WriteLine("Please enter max cargo weight for the truck, min is: 0 and max is: 10,000");
                cargo = Console.ReadLine();
            }

            return maxCargo;
        }

        public static Enums.Status GetStatusFilter()
        {
            {
                string filter = string.Empty;
                while (!(filter.Equals("0") || filter.Equals("1") || filter.Equals("2") || filter.Equals("3")))
                {
                    Console.WriteLine("Please choose one of the options:");
                    Console.WriteLine("0. All the Vehicle plates in the Garage");
                    Console.WriteLine(string.Format("1.{0}\n2.{1}\n3.{2}", Enums.Status.UnderRepair, Enums.Status.RepairDone, Enums.Status.Payed));
                    filter = Console.ReadLine();
                }

                Enums.Status filterChoise = Enums.Status.Defualt;
                switch (filter)
                {
                    case "1":
                        filterChoise = Enums.Status.UnderRepair;
                        break;

                    case "2":
                        filterChoise = Enums.Status.RepairDone;
                        break;

                    case "3":
                        filterChoise = Enums.Status.Payed;
                        break;

                }

                return filterChoise;
            }
        }

        public static Enums.Status VaildStatus()
        {
            string status = string.Empty;
            while (!(status.Equals("0") || status.Equals("1") || status.Equals("2") || status.Equals("3")))
            {
                Console.WriteLine("Please choose the new status:");
                Console.WriteLine(string.Format("1.{0}\n2.{1}\n3.{2}", Enums.Status.UnderRepair, Enums.Status.RepairDone, Enums.Status.Payed));
                status = Console.ReadLine();
            }

            Enums.Status filterChoise = Enums.Status.Defualt;
            switch (status)
            {
                case "1":
                    filterChoise = Enums.Status.UnderRepair;
                    break;

                case "2":
                    filterChoise = Enums.Status.RepairDone;
                    break;

                case "3":
                    filterChoise = Enums.Status.Payed;
                    break;

            }
            return filterChoise;
        }

        public static float GetEnergyAmount(string i_amount)
        {
            float amountToAdd;
            while(!float.TryParse(i_amount, out amountToAdd))
            {
                Console.WriteLine("Please enter a number");
                i_amount = Console.ReadLine();
            }
            
            return amountToAdd;
        }
    }
}
