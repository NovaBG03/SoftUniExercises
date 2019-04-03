using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp51
{
    class Cash
    {
        private string name;
        private long quantity;

        public Cash(string name, long quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public long Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}
