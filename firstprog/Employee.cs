// DERIVED CLASS
using System;
namespace firstprog
{
    // At max only one class can be inherited
    public class Employee : Person
    {
        public Employee()
        {   
            System.Console.WriteLine( "ctor of derived called");
        }
        // override of DOB from Person(Base class)
        public override void DOB()
        {
            Console.WriteLine("DOB of derived class called");
        }
    }
}