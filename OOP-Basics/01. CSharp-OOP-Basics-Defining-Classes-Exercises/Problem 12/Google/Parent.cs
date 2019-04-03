using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    class Parent
    {
        private string name;
        private DateTime birthday;

        public Parent(string name, DateTime birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

    }
}
