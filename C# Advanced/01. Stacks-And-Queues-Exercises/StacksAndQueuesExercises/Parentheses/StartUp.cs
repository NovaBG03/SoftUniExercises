using System;
using System.Collections.Generic;
using System.Linq;

namespace Parentheses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<char> perantheses = new Stack<char>();
            char[] openningPerantheses = { '(', '[', '{' };

            string input = Console.ReadLine();

            bool isBalanced = true;

            for (int i = 0; i < input.Length; i++)
            {
                char bracket = input[i];

                if (openningPerantheses.Contains(bracket))
                {
                    perantheses.Push(input[i]);
                    continue;
                }

                if (perantheses.Count == 0)
                {
                    isBalanced = false;
                    break;
                }

                if (bracket == ')' && '(' != perantheses.Pop())
                {
                    isBalanced = false;
                    break;
                }
                else if (bracket == ']' && '[' != perantheses.Pop())
                {
                    isBalanced = false;
                    break;
                }
                else if (bracket == '}' && '{' != perantheses.Pop())
                {
                    isBalanced = false;
                    break;
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
