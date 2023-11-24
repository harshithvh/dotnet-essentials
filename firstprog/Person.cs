// BASE CLASS
using System;
namespace firstprog
{
    public class Person
    {
        public Person()
        {
            Console.WriteLine("ctor of base called");
        }
        public void Name()
        {
            Console.WriteLine("Name of base called");
        }
        // virtual since this method is being overriden in Employee class
        public virtual void DOB()
        {
            Console.WriteLine("DOB of base class called");
        }
        private void M1() 
        {

        }
        protected void ProtectM() 
        {

        }
        // Only fields or functions can be made protected internal
        // protected internal are only visible in inherited classes
        protected internal void PIM() 
        {

        }
    
    }
}