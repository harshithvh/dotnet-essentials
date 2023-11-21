  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeObject.MyObject
{
    // access modifiers
    // private, public, internal, protected and internal protected
    // Classes under namespace can either be public/internal
    // if made public it will be availabe in the current package also visible to packages outside
    // if made internal -> will be visible only within the current package (EmployeeObject)
    internal class Employee
    {
        //internal int EmployeeId;
        // if access modifier is not mentioned then default is private

        // use ctor shortcut for default constructor
        public Employee()
        {   
            DOB = DateTime.Now;
            EmployeeCounter++;
        }

        // this() will call the default Employee() constructor and then executes the next three lines
        public Employee(int eid, string name) :this()
        {
            EmployeeId = eid;
            Name = name;
            Salary = 10000;
        }

        // use propfull shortcut(TAB)
        private int _intEmployeeId;
        public int EmployeeId
        {
            get 
            { 
                  return _intEmployeeId;
            }
            set 
            { 
                if(value > 0) { 
                    _intEmployeeId = value;
                }
                else
                {
                    throw new Exception("Invalid Id");
                }
            } 
        }

        private string _strName;

        public string Name
        {
            get { return _strName; }
            set { 
                if(value.Length > 3) { 
                    _strName = value;
                }
                else { throw new Exception("Name shd have 3 chars atleast"); }
            }
        }

        private DateTime _dtDOB;

        public DateTime DOB
        {
            get { return _dtDOB; }
            set { 
                if (value.CompareTo(DateTime.Now) <= 0) { 
                    _dtDOB = value; 
                }
                else { throw new Exception("DOB should be less than today"); }
            }
        }

        private double _dbSal;

        public double Salary
        {
            get { return _dbSal; }
            set { _dbSal = value; }
        }

        // if there are no validations to be made:
        //public double Salary { get; set; }

        private static int EmpCounter;

        public static int EmployeeCounter { 
            get { return EmpCounter; } 
            set { EmpCounter = value; } 
        }

        StringBuilder sb;
        // string datatype is imm  utable hence use stringBuilder
        public string Display()
        {
            sb =  new StringBuilder();
            sb.Append("Emp Id " + EmployeeId + "\n");
            sb.Append("Emp Name " + Name + "\n");
            sb.Append("Emp DOB " + DOB.ToShortDateString() + "\n");
            sb.Append("Emp Salary " + Salary + "\n");
            return sb.ToString(); // convert char array to string
        }
        // Destructor (dispose) called whenever invoked
        public void Dispose()
        {
            sb = null;
            Console.WriteLine("Release all the resources like array, collection, db connections etc");
        }

        // Destructor/Finalize are in-deterministic they can be called without your knowledge
        ~Employee()
        {
            Console.WriteLine("Destructors are in-deterministic in .net framework");
        }

    }
}
