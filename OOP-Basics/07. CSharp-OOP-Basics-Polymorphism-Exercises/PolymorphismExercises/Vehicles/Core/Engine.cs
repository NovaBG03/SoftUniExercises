using System;
using VehiclesProblem.Vehicles;
using VehiclesProblem.Vehicles.Contracts;

namespace VehiclesProblem.Core
{
    public class Engine
    {
        private const int vechicleCount = 3;

        private IVehicle car;
        private IVehicle truck;
        private IVehicle bus;

        public Engine()
        {

        }

        public void Run()
        {
            for (int i = 0; i < vechicleCount; i++)
            {
                string[] Input = Console.ReadLine().Split();
                string type = Input[0];
                double fuelQuantity = double.Parse(Input[1]);
                double fuelConsumption = double.Parse(Input[2]);
                double tankCapacity = double.Parse(Input[3]);

                switch (type)
                {
                    case "Car":
                        car = new Car(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                    case "Truck":
                        truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                    case "Bus":
                        bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                        break;
                }
            }

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicleType = input[1];
                double value = double.Parse(input[2]);

                try
                {
                    DoCommand(command, vehicleType, value);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);

            Console.ReadLine();
        }

        private void DoCommand(string command, string vehicleType, double value)
        {
            if (command == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(value));
                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(value));
                }
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(value));
                }
            }
            else if (command == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuele(value);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuele(value);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuele(value);
                }
            }
            else if (command == "DriveEmpty")
            {
                Console.WriteLine((bus as Bus).DriveEmpty(value));
            }
        }

    }
}
