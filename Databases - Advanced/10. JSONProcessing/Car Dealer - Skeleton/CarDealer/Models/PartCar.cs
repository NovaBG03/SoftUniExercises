using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Models
{
    public class PartCar 
    {
        public int PartId { get; set; }
        public Part Part { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }

    public class PartCarComparer : IEqualityComparer<PartCar>
    {
        public bool Equals(PartCar x, PartCar y)
        {
            return x.PartId == y.PartId
                && x.CarId == y.CarId;
        }

        public int GetHashCode(PartCar obj)
        {
            return obj.PartId + obj.CarId;
        }
    }
}
