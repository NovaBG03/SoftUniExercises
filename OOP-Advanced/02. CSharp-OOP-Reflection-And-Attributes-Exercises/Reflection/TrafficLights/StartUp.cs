using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficLights
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<TrafficLight> trafficLights  = new List<TrafficLight>();

            var lightsInput = Console.ReadLine().Split();

            foreach (var lightAsString in lightsInput)
            {
                Light light = (Light)Enum.Parse(typeof(Light), lightAsString);

                TrafficLight trafficLight = new TrafficLight(light);

                trafficLights.Add(trafficLight);
            }

            int updatesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < updatesCount; i++)
            {
                foreach (var trafficLight in trafficLights)
                {
                    trafficLight.Update();
                }

                Console.WriteLine(string.Join(" ", trafficLights));
            }

        }
    }
}
