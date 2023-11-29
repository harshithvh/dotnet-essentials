using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class MyClass
    {
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public double Salary { get; set; }
        public int DeptId { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>
            {
                new Department { Id = 1, Name="Dept1"},
                new Department { Id = 2, Name="Dept2"},
                new Department { Id = 3, Name="Dept3"},
                new Department { Id = 4, Name="Dept4"},
            };

            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                     Name="UEmp",
                      DOB=new DateTime(1999,1,1),
                       DeptId=1,
                        Salary=10000
                },
                new Employee
                {
                    Id = 2,
                     Name="TEmp",
                      DOB=new DateTime(1991,3,2),
                       DeptId=2,
                        Salary=20000
                },
                new Employee
                {
                    Id = 3,
                     Name="IEmp",
                      DOB=new DateTime(2000,6,3),
                       DeptId=3,
                        Salary=30000
                },
                new Employee
                {
                    Id = 4,
                     Name="AEmp",
                      DOB=new DateTime(2002,6,7),
                       DeptId=1,
                        Salary=40000
                },
                new Employee
                {
                    Id = 5,
                     Name="CEmp",
                      DOB=new DateTime(1998,7,9),
                       DeptId=2,
                        Salary=50000
                }
            };

            IEnumerable<Employee> employees1 = from Employee item in employees
                                               where item.Id > 1
                                                && item.DOB > new DateTime(1999,1,1)
                                               orderby item.Name ascending
                                               select item;

            IEnumerable<string> nameofemps = from emp in employees
                                             select emp.Name;

            // since we wanted to club name and salary
            IEnumerable<MyClass> nameofemps2 = from emp in employees
                                               orderby emp.Name ascending
                                               select new MyClass
                                               { Name = emp.Name, Salary = emp.Salary };

            double totalsalary = employees.Sum(emp => emp.Salary);

            // join operation between two sequences, departments and employees, based on a common property (Id in this case)
            // use var since this is an anonymous object
            var employees11 = from Department dept in departments
                              join Employee item in employees
                              on dept.Id equals item.Id
                              orderby item.DOB descending
                              // new anonymous object which combine data from both Department and Employee objects.
                              select new
                              {
                                  Name = item.Name,
                                  DOB = item.DOB,
                                  Salary = item.Salary,
                                  DeptName = dept.Name
                              };

            foreach (string emp in nameofemps)
            {
                Console.WriteLine(emp);
            }

            foreach (var item in employees1)
            {
                Console.WriteLine($" {item.Name}     {item.DOB.ToShortDateString()}    {item.DeptId}    {item.Salary}         ");
            }

            foreach (MyClass emp in nameofemps2)
            {
                Console.WriteLine("Name: {0}, Salary: {1}", emp.Name, emp.Salary);
            }

            foreach (var item in employees11)
            {
                Console.WriteLine($" {item.Name}     {item.DOB.ToShortDateString()}    {item.DeptName}    {item.Salary}         ");
            }

        }
    }
}
