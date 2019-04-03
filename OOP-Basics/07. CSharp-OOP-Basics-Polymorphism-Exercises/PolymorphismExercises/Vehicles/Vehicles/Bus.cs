using VehiclesProblem.Vehicles;

namespace VehiclesProblem.Vehicles
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelConsumptionIncrease;
        }

        public string DriveEmpty(double distance)
        {
            double fuelConsumption = this.FuelConsumption - fuelConsumptionIncrease;
            double consumedFuel = distance * fuelConsumption;

            if (consumedFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= consumedFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
