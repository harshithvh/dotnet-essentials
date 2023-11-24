using System;

namespace firstprog
{
    class Program
    {
        static void Main(string[] args)
        {
            Person obj1 = new Person();
            obj1.DOB();
              
            // since Employee is inherited from Person hence calling Emplyoee
            // constructor will also call Person constructor
            Employee obj2 = new Employee();
            obj2.DOB();
            Console.ReadLine();
            
        }
    }
}
