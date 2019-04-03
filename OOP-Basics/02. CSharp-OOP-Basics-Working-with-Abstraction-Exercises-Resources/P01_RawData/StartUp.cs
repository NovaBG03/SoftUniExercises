using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                KeyValuePair tire1 = KeyValuePair.Create(tire1Pressure, tire1Age);

                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                KeyValuePair tire2 = KeyValuePair.Create(tire2Pressure, tire2Age);

                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                KeyValuePair tire3 = KeyValuePair.Create(tire3Pressure, tire3Age);

                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);
                KeyValuePair tire4 = KeyValuePair.Create(tire4Pressure, tire4Age);

                KeyValuePair<double, int>[] tires = new KeyValuePair<double, int>[]
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Key < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
