using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    class Cargo
    {
        //<CargoWeight> <CargoType> 
        private int cargoWeight;
        private string cargoType;

        public Cargo(int weight, string type)
        {
            this.CargoWeight = weight;
            this.CargoType = type;
        }


        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

    }
}
