using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Engine
    {
        //<EngineSpeed> <EnginePower>
        private int engineSpeed;
        private int enginePower;

        public Engine(int speed, int power)
        {
            this.EngineSpeed = speed;
            this.EnginePower = power;
        }
        

        public int EngineSpeed
        {
            get { return engineSpeed; }
            set { engineSpeed = value; }
        }

        public int EnginePower
        {
            get { return enginePower; }
            set { enginePower = value; }
        }



    }
}
