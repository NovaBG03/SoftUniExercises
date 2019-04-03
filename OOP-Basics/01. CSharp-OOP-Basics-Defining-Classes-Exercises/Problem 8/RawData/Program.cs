using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                //< Model > < EngineSpeed > < EnginePower > < CargoWeight > < CargoType > 
                //    < Tire1Pressure > < Tire1Age > < Tire2Pressure > < Tire2Age >
                //    < Tire3Pressure > < Tire3Age > < Tire4Pressure > < Tire4Age >
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double[] tirePressure = new double[4];
                int[] tireAge = new int[4];

                int j = 0;
                for (int k = 5; k < 12; k += 2)
                {
                    tirePressure[j] = double.Parse(input[k]);
                    tireAge[j] = int.Parse(input[k + 1]);
                    j++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Tire tire = new Tire(tirePressure, tireAge);

                Car car = new Car(model, engine, cargo, tire);
                cars.Add(car);
            }

            string type = Console.ReadLine();

            if (type == "fragile")
            {
                foreach (Car car in cars.FindAll(x => x.Cargo.CargoType == type))
                {
                    foreach (var tirePressure in car.Tire.TirePressue)
                    {
                        if (tirePressure < 1)
                        {
                            Console.WriteLine(car.Model);
                            break;
                        }
                    }
                }
            }
            else if (type == "flamable")
            {
                foreach (Car car in cars.FindAll(x => x.Cargo.CargoType == type))
                {
                    if (car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
