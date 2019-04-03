using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person(12);
            Person person3 = new Person("Ivan", 15);

        }
    }
}
