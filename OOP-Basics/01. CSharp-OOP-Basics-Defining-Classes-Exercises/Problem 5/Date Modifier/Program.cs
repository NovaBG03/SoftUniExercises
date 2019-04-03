using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();
            DateModifie difference = new DateModifie();

            difference.DifferenceInDays(date1, date2);

            Console.WriteLine(difference.DateDifference);

            Console.ReadLine();
        }
    }
}
