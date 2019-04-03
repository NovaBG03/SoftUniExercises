using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private KeyValuePair<double, int>[] tires;


        public Car(string model, Engine engine, Cargo cargo, KeyValuePair<double, int>[] tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = Cargo;
            this.Tires = tires;
        }

        public string Model { get => model; set => model = value; }

        public Engine Engine { get => engine; set => engine = value; }

        public Cargo Cargo { get => cargo; set => cargo = value; }

        public KeyValuePair<double, int>[] Tires { get => tires; set => tires = value; }
        
    }
}
