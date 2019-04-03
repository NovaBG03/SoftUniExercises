using System;
using VehiclesProblem.Vehicles.Contracts;

namespace VehiclesProblem.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity = 0;
        private double fuelConsumption;
        private double tankCapacuty;


        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacuty)
        {
            this.TankCapacity = tankCapacuty;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }


        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (this.FuelQuantity + value > this.TankCapacity)
                {
                    return;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get => fuelConsumption;
            protected set => fuelConsumption = value;
        }

        public double TankCapacity
        {
            get => tankCapacuty;
            private set => tankCapacuty = value;
        }


        public string Drive(double distance)
        {
            double consumedFuel = distance * this.FuelConsumption;

            if (consumedFuel > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= consumedFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public void Refuele(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            double addedfuel = fuel;
            if (this is Truck)
            {
                addedfuel *= 0.95;
            }

            if (this.fuelQuantity + addedfuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit { fuel } fuel in the tank");
            }

            this.FuelQuantity += addedfuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
