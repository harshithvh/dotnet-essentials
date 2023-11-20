using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    delegate long MyDelegate(int n1, int n2);
    delegate void MCDelegate();

    class MathClass
    {
        public long Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public long Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public void M1() {
            Console.WriteLine("M1 invoked");
        }
        public void M2()
        {
            Console.WriteLine("M2 invoked");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del1, del2;

            MathClass math = new MathClass();

            del1 = new MyDelegate(math.Add);

            del2 = new MyDelegate(math.Multiply);

            Console.WriteLine(del1.Invoke(22,22));
            Console.WriteLine(del2.Invoke(2,3));

            MCDelegate del;
            del = new MCDelegate(math.M1);
            // Remove the + operator to see the difference
            del += new MCDelegate(math.M2);
            del.Invoke();

            Console.ReadLine();
        }
    }
}
