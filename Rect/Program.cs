using System;

namespace Rect
{
    class Program
    {
        static void Main(string[] args)
        {
            Point pointA = new Point();
            pointA.x = 1;
            pointA.Print();

            Point pointB = pointA.Move(3);
            pointB.Print();

            Rect rect = new Rect();
            rect.width = 2;
            rect.height = 1;

            rect.Print();
            rect.Scale(4);
            rect.Print();

            Console.WriteLine(rect.GetArea());
            Console.WriteLine(rect.GetPerimeter());
            Rect rect2 = rect.Move(4);
            rect2.Print();

            string str = "";
            string[] arr = str.Split(',');
            Console.WriteLine(arr.Length + " " + arr[0]);
        }

        struct Point
        {
            public int x;
            public int y;

            public void Print()
            {
                Console.WriteLine(this);
            }

            public override string ToString()
            {
                return $"(x: {x}, y: {y})";
            }

            public Point Move(int offset)
            {
                return new Point()
                {
                    x = this.x + offset,
                    y = this.y + offset,
                };
            }
        }

        class Rect
        {
            public Point topLeft;
            public int width;
            public int height;

            public void Print()
            {
                Console.WriteLine($"[{topLeft}; {width} x {height}]");
            }

            public void Scale(int factor)
            {
                width *= factor;
                height *= factor;
            }

            public int GetArea()
            {
                return Math.Abs(width - topLeft.x) * Math.Abs(height - topLeft.y);
            }

            public int GetPerimeter()
            {
                return 2 * Math.Abs(width - topLeft.x) + 2 * Math.Abs(height - topLeft.y);
            }

            public Rect Move(int offset)
            {
                return new Rect()
                {
                    topLeft = topLeft.Move(offset)
                };
            }
        }
    }
}
