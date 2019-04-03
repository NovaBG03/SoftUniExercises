using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Tire
    {
        //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
        private double[] tirePressure;
        private int[] tireAge;

        public Tire(double[] pressue, int[] age)
        {
            this.TirePressue = pressue;
            this.TireAge = age;
        }


        public double[] TirePressue
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

        public int[] TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }
    }
}
