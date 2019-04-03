using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        //<Model> <Engine> <Weight> <Color>
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine, weight)
        {
            this.Color = color;
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

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public override string ToString()
        {
            //<CarModel>:
            //  <EngineModel>:
            //      Power: <EnginePower>
            //      Displacement: <EngineDisplacement>
            //      Efficiency: <EngineEfficiency>
            //  Weight: <CarWeight>
            //  Color: <CarColor>

            string result = string.Format($"{this.Model}:");
            result += string.Format($"\n  {this.Engine.Model}:");
            result += string.Format($"\n      Power: {this.Engine.Power}");
            if (this.Engine.Displacement == -1)
            {
                result += string.Format("\n      Displacement: n/a");
            }
            else
            {
                result += string.Format($"\n      Displacement: {this.Engine.Displacement}");
            }
            result += string.Format($"\n      Efficiency: {this.Engine.Efficiency}");
            if (this.Weight == -1)
            {
                result += string.Format("\n  Weight: n/a");
            }
            else
            {
                result += string.Format($"\n  Weight: {this.Weight}");
            }
            result += string.Format($"\n  Color: {this.Color}");

            return result;
        }

    }
}
