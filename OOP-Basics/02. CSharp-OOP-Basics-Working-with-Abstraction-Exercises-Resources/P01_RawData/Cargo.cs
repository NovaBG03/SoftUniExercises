﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }


        public int Weight { get => weight; set => weight = value; }
        public string Type { get => type; set => type = value; }
    }
}
