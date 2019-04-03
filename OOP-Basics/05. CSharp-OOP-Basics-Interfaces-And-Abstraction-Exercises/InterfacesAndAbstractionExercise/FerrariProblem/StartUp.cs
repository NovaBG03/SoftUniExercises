using System;

namespace FerrariProblem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ICar car = new Ferrari();

            string driverName = Console.ReadLine();
            car.DriverName = driverName;

            Console.WriteLine($"{car.Model}/{car.PushBrakes()}/{car.PushGasPedal()}/{car.DriverName}");
        }
    }
}
