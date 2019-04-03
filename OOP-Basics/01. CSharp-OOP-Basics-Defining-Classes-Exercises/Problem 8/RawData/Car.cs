using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Car
    {
        //model, engine, cargo and a collection of exactly 4 tires
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire tire;

        public Car(string model, Engine engine, Cargo cargo, Tire tire)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public Tire Tire
        {
            get { return tire; }
            set { tire = value; }
        }
            
    }
}
