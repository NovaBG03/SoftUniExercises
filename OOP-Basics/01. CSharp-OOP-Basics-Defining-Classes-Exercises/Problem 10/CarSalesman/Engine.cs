﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        //<Model> <Power> <Displacement> <Efficiency>
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency )
            : this(model, power, displacement)
        {
            this.Efficiency = efficiency;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }

        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }




    }
}
