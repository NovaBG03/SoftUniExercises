﻿namespace VehiclesProblem.Vehicles
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += fuelConsumptionIncrease;
        }
    }
}
