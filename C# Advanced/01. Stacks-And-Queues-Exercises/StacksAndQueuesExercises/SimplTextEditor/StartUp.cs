using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> lastText = new Stack<string>();

            string text = string.Empty;

            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];

                switch (command)
                {
                    case "1":
                        lastText.Push(text);
                        string textToAdd = input[1];
                        text += textToAdd;
                        break;
                    case "2":
                        lastText.Push(text);
                        int elementsCount = int.Parse(input[1]);
                        text = text.Substring(0, text.Length - elementsCount);
                        break;
                    case "3":
                        int index = int.Parse(input[1]);
                        index--;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text = lastText.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}