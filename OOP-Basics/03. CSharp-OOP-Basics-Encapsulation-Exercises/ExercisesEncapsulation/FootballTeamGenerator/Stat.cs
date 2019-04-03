using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamGenerator
{
    public class Stat
    {
        private string name;
        private int size;

        public Stat(string name, int size)
        {
            this.Name = name;
            this.Size = size;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Size
        {
            get { return size; }
            set
            {
                if (value < 0 || value > 100)
                {
                    SizeException();
                }
                size = value;
            }
        }

        private void SizeException()
        {
            throw new ArgumentException($"{this.Name} should be between 0 and 100.");
        }
    }
}
