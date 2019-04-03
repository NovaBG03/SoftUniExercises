using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                //< Model > < FuelAmount > < FuelConsumptionFor1km >

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            do
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End") 
                {
                    break;
                }

                if (input[0] == "Drive")
                {
                    string model = input[1];
                    double distanceTraveled = double.Parse(input[2]);

                    cars.Find(x => x.Model == model).Drive(distanceTraveled);
                }

            } while (true);

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
            }

            Console.ReadLine();
        }
    }
}
