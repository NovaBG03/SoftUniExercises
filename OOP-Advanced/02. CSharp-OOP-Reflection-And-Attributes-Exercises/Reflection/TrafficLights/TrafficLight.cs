using System.Collections.Generic;

namespace TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Light light)
        {
            this.Light = light;
        }

        private Light Light { get; set; }

        public void Update()
        {
            this.Light++;

            if (this.Light > Light.Red)
            {
                this.Light -= 3;
            }
        }

        public override string ToString()
        {
            return this.Light.ToString();
        }
    }
}
