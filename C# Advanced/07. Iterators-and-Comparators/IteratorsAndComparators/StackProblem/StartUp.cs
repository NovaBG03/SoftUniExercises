using System;

namespace StackProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];

                switch (command)
                {
                    case "Push":
                        for (int i = 1; i < input.Length; i++)
                        {
                            stack.Push(int.Parse(input[i]));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (IndexOutOfRangeException ie)
                        {
                            Console.WriteLine(ie.Message);
                        }
                        break;
                    case "END":
                        for (int i = 0; i < 2; i++)
                        {
                            foreach (var item in stack)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
