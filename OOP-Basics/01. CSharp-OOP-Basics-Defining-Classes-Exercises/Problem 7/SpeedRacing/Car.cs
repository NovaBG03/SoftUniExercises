using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer. traveled distance

        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double traveledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.traveledDistance = 0.00;
        }


        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public double TraveledDistance
        {
            get { return this.traveledDistance; }
            set { this.traveledDistance = value; }
        }


        public void Drive(double distance)
        {
            if (distance * this.FuelConsumption > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumption;
                this.TraveledDistance += distance;
            }
        }


    }
}
