﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    class Car
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.Model = model;
            this.Speed = speed;
        }


        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

    }
}
