using System;

namespace ProblemBox
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        

        public double Length
        {
            private get { return length; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            private get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            private get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        private double CalculateSurfaceArea()
        {
            return this.CalculateLateralSurfaceArea() + 2 * this.Length * this.Width;
        }

        private double CalculateLateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        private double CalculateVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            return $"Surface Area – {this.CalculateSurfaceArea():f2}\n" +
                $"Lateral Surface Area – {this.CalculateLateralSurfaceArea():f2}\n" +
                $"Volume – {this.CalculateVolume():f2}";
        }

    }
}
