using System;
using System.Linq;

namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split()
                .ToList();

            list.Remove("Create");

            ListyIterator<string> collection = new ListyIterator<string>(list.ToArray());

            while (true)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "Move":
                        Console.WriteLine(collection.MoveNext());
                        break;
                    case "Print":
                            collection.Print();
                        break;
                    case "PrintAll":
                        foreach (var item in collection)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                        break;
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "END":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
