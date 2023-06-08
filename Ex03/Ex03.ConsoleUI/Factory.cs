
using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Factory
    {  
        private static float newEnergyPercentage;
        private static Wheel[] wheels;

        public static Vehicle GetInstansOf(string i_licenseNumber, Enums.VehicleType i_ModelName)
        {
            float maxEngineCapacity;
            wheels = getWheel();
            Enums.EnergyType energyType = UserInputValidator.GetEngineType();
            maxEngineCapacity = UserInputValidator.GetMaxEnegineCapactiy();
            newEnergyPercentage = UserInputValidator.GetEnergyPercentage(maxEngineCapacity);
            Vehicle vehicle = null;
            switch (i_ModelName)
            {
                case Enums.VehicleType.Car:
                    vehicle = GetCarInstats(i_licenseNumber, newEnergyPercentage, wheels, energyType, maxEngineCapacity);
                    break;

                case Enums.VehicleType.Motorcyle:
                    vehicle = GetMotorcycleInstats(i_licenseNumber, newEnergyPercentage, wheels, energyType, maxEngineCapacity);
                    break;

                case Enums.VehicleType.Truck:
                    vehicle = GetTruckInstats(i_licenseNumber, newEnergyPercentage, wheels, energyType, maxEngineCapacity);
                    break;

            }

            return vehicle;
        }
        
        public static Car GetCarInstats(string i_licenseNumber, float i_newEnergyPercentage, Wheel[] i_wheels, Enums.EnergyType i_energyType, float i_MaxEngineCapacity)
        {
            
            Enums.CarColor carColor = UserInputValidator.GetCarColor();
            Enums.CarNumberOfDoors carNumOfDoors = UserInputValidator.GetCarDoors();
            return new Car("Car", i_licenseNumber, i_newEnergyPercentage, i_wheels, i_energyType, carColor, carNumOfDoors, i_MaxEngineCapacity);
        }

        public static Motorcycle GetMotorcycleInstats(string i_licenseNumber, float i_newEnergyPercentage, Wheel[] i_wheels, Enums.EnergyType i_energyType, float i_MaxEngineCapacity)
        {
            int engineCapacity;
            Enums.MotorcycleLicenseType licenseType = UserInputValidator.GetLicenseType();
            engineCapacity = UserInputValidator.GetMotorcycleEngineCapacity();
            return new Motorcycle("Motorcycle", i_licenseNumber, i_newEnergyPercentage, i_wheels, i_energyType, licenseType, engineCapacity, i_MaxEngineCapacity);
        }

        public static Truck GetTruckInstats(string i_licenseNumber, float i_newEnergyPercentage, Wheel[] i_wheels, Enums.EnergyType i_energyType, float i_MaxEngineCapacity)
        { 
            bool carryHazardMaterials = UserInputValidator.CarryMaterials();
            float maxCargo = UserInputValidator.GetMaxCargo();
            return new Truck("Truck", i_licenseNumber, i_newEnergyPercentage, i_wheels, i_energyType, carryHazardMaterials, maxCargo, i_MaxEngineCapacity);
        }

        private static Wheel[] getWheel()
        {
            string amount;
            int wheelsAmount;
            string factory;
            float currentAirPressure;
            float maxAirPressure;
            Wheel[] wheels;

            Console.WriteLine("Please enter amount of the wheels");
            amount = Console.ReadLine();
            wheelsAmount = UserInputValidator.GetWheelAmount(amount);
            Console.WriteLine("Please enter factory of the wheels");
            factory = UserInputValidator.GetValidFactory(Console.ReadLine());
            Console.WriteLine("Please enter Max airpressure of the wheels");
            maxAirPressure = UserInputValidator.GetMaxAirPressure(Console.ReadLine());
            Console.WriteLine("Please enter current airpressure of the wheels");
            currentAirPressure = UserInputValidator.GetCurrentAirPressure(Console.ReadLine(),maxAirPressure);
            wheels = new Wheel[wheelsAmount];
            Wheel wheel = new Wheel(factory, currentAirPressure, maxAirPressure);
            wheels[0] = wheel;
            for (int i = 1; i < wheelsAmount; i++)
            {
                wheels[i] = wheel.DuplicateWheel();
            }

            return wheels;
        }
    } 
}
