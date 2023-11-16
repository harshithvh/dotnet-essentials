using System;

namespace AbstractAndArray
{
    internal class Program
    {
        // This method doesn't have an implementation (it's just a method signature with no code inside)
        // so any class that inherits from Animal must implement this method, by overriding it
        // Note that we cannot create an instance of an abstract class directly
        abstract class Shape
        {
            public int NoOfPoints;

            public void M1()
            {

            }

            public abstract void Draw();
            public abstract void Move();
        }

        class Square : Shape
        {
            public Square() {
                NoOfPoints = 4;
            }
            public override void Draw()
            {
                Console.WriteLine($"Drawing a {NoOfPoints} sided square");
            }

            public override void Move()
            {
                Console.WriteLine($"Moving a {NoOfPoints} sided square");
            }
        }

        class Pentagon : Shape
        {
            public Pentagon() { 
                NoOfPoints = 5;
            }
            public override void Draw()
            {
                Console.WriteLine($"Drawing a {NoOfPoints} sided pentagon");
            }

            public override void Move()
            {
                Console.WriteLine($"Moving a {NoOfPoints} sided pentagon");
            }
        }
        static void Main(string[] args)
        {
            //Shape shape = new Shape(); cannot be done
            Shape shape1 = new Square();

            Shape shape2 = new Pentagon();


            shape1.Draw();//this is resolved during runtime
            shape2.Move();

            // Arrays
            string[] myweekdays = new string[5];
            myweekdays[0] = "Sunday";
            myweekdays[1] = "Monday";
            myweekdays[2] = "Tuesday";
            myweekdays[3] = "Wed";
            myweekdays[4] = "Thur";

            Console.WriteLine("Length {0} and Rank {1}", myweekdays.Length, myweekdays.Rank);
            Console.WriteLine($"Length {myweekdays.Length} and Rank {myweekdays.Rank}");

            string[] mystrings = { "Item1", "Item2", "Item3" };


            int[] myints = new int[10];
            for (int i = 0; i < myints.Length; i++)
            {
                myints[i] = i + 1;
            }

            string[,] twod = new string[3, 2];
            twod[0, 0] = "item1";
            twod[0, 1] = "item2";
            twod[1, 0] = "item11";
            twod[1, 1] = "item22";
            twod[2, 0] = "item111";
            twod[2, 1] = "item222";

            Console.WriteLine($"{twod.Length}");
            Console.WriteLine($"{twod.GetLength(0)}");

            string[][] jagged = new string[2][];

            jagged[0] = new string[2] { "item1", "item2" };
            jagged[1] = new string[4] { "item11", "item22", "item33", "item44" };

            int ii = 10;
            M(ref ii);
            Console.WriteLine(ii);
            Console.WriteLine();

            N(1, 2, 3, 4);

            Print(myweekdays.GetEnumerator());
            Print(myints.GetEnumerator());

            Square[] squares = new Square[2];

            // For the squares array, two instances of the Square class are created and assigned to the first and second elements of the array
            squares[0] = new Square();
            squares[1] = new Square();

            Print(squares.GetEnumerator());

            Shape[] shapes = new Shape[2];
            // For the shapes array, two instances of two different classes, Square and Pentagon, are created and assigned to the first and second elements of the array
            shapes[0] = new Square();
            shapes[1] = new Pentagon();

            Print(shapes.GetEnumerator());
        }

        static void M(ref int arg)
        {
            arg += 2;
        }

        static void N(params int[] arg) { }

        static void Print(System.Collections.IEnumerator ie)
        {
            while (ie.MoveNext())
            {
                if (ie.Current is Square)
                {
                    // ie.Current as Square is a type conversion using the as operator
                    // If the cast is successful, sq will be a reference to the same object as ie.Current else NULL
                    Square sq = ie.Current as Square;
                    sq.Draw();
                }
                else if (ie.Current is Shape)
                {
                    Shape s = ie.Current as Shape;
                    s.Draw();   //polymorphisum
                }
                else
                    Console.WriteLine(ie.Current);
            }
        }
    }
}
