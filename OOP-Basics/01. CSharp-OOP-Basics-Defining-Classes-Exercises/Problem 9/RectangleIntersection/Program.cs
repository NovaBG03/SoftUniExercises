using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            string[] nm = Console.ReadLine().Split();
            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                //id, width, height and coordinates
                string id = input[0];
                int width = int.Parse(input[1]);
                int height = int.Parse(input[2]);
                int x = int.Parse(input[3]);
                int y = int.Parse(input[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);

                rectangles.Add(rectangle);
            }

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split();
                string id1 = input[0];
                string id2 = input[1];

                Rectangle rectangle1 = rectangles.FirstOrDefault(x => x.Id == id1);
                Rectangle rectangle2 = rectangles.FirstOrDefault(x => x.Id == id2);

                Console.WriteLine(rectangle1.Intersects(rectangle2));
            }

            Console.ReadLine();
        }
    }
}
