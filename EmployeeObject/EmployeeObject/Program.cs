using EmployeeObject.MyObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1, emp2;

            emp1 = new Employee();
            emp2 = new Employee();
            //emp2 = new Employee(20, "Test2");

            emp1.EmployeeId = 10;
            emp1.Name = "Test1";
            emp1.DOB = new DateTime(2002, 2, 2);
            emp1.Salary = 292.23;

            emp2.EmployeeId = 20;
            emp2.Name = "Test2";
            emp2.DOB = Convert.ToDateTime("12/2/1999");
            emp2.Salary = 292.23;

            Console.WriteLine(emp1.EmployeeId + " " + emp2.EmployeeId);
            Console.WriteLine(emp1.Name + " " + emp2.Name);

            Console.WriteLine(emp1.Display());
            Console.WriteLine(emp2.Display());


            emp1.Dispose();
            emp2.Dispose();

            // assigning emp1/emp2 to NULL will not remove its reference to the EmployeeObject GC has to remove it
            emp1 = null;
            emp2 = null;     

            Console.WriteLine("Number of employee objects is {0}", Employee.EmployeeCounter);

            // Explicitly call GC - Destructor/Finalize invoked as GC finds emp1 & emp2 assigned to null
            // GC deletes only those objects which are dead
            System.GC.Collect();

            Console.ReadLine();

        }
    } 
}
