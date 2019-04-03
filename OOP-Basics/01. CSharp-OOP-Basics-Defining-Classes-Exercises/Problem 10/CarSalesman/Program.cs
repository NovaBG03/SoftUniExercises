using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInput = Console.ReadLine().Split();
                //< Model > < Power > < Displacement > < Efficiency >
                string model = engineInput[0];
                int power = int.Parse(engineInput[1]);

                Engine engine = new Engine(model, power);

                if (engineInput.Length == 3)
                {
                    if (engineInput[2].All(char.IsDigit))
                    {
                        int displacement = int.Parse(engineInput[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = engineInput[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (engineInput.Length == 4)
                {
                    int displacement = int.Parse(engineInput[2]);
                    string efficiency = engineInput[3];
                    
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInput = Console.ReadLine().Split();
                //< Model > < Engine > < Weight > < Color > 
                string model = carInput[0];
                string engineModel = carInput[1];
                Engine engine = engines.Find(x => x.Model == engineModel);

                Car car = new Car(model, engine);

                if (carInput.Length == 3)
                {
                    if (carInput[2].All(char.IsDigit))
                    {
                        int weight = int.Parse(carInput[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInput[2];
                        car.Color = color;
                    }
                }
                else if(carInput.Length == 4)
                {
                    int weight = int.Parse(carInput[2]);
                    string color = carInput[3];

                    car.Weight = weight;
                    car.Color = color;
                }

                cars.Add(car);
            }

            Console.WriteLine();

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }

            Console.ReadLine();
        }
    }
}
