using EmpMgmtDAL.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpMgmtDAL
{
    // using LINQ to query the database
    public class EmployeeRepository : IRepository<Employee>
    {
        EmpMgmtDbContext context;
        public EmployeeRepository(EmpMgmtDbContext ctx)
        {
            // context has access to all the dbset defined in EmpMgmtDbContext
            context = ctx;
        }
        public bool Add(Employee entity)
        {
            context.Employees.Add(entity);
            int noofrowsaff = context.SaveChanges();
            return noofrowsaff > 0; // if none of the rows are effected it will return 0
        }

        public IEnumerable<Employee> Find(string name)
        {
            IEnumerable<Employee> list = from item in context.Employees
                                      .Include("Department")
                                      .Include("Grade")
                                         where item.Status == 1 && item
                                                .Name.ToLower().StartsWith(name.ToLower())
                                         orderby item.Name
                                         select item;
            return list;
        }

        public IEnumerable<Employee> GetAll()
        {
            // Include() does a JOIN operation between the Employees and Departments tables in the database and does query based on foreign key value stored in the Employees table.
            IEnumerable<Employee> list = from item in context.Employees
                                         .Include("Department")
                                         .Include("Grade")
                                         where item.Status == 1
                                         orderby item.Name
                                         select item;
            return list;
        }

        public Employee GetById(int id)
        {
            IEnumerable<Employee> list = from item in context.Employees
                                        .Include("Department")
                                        .Include("Grade")
                                         where item.Status == 1 && item.EmpId == id
                                         orderby item.Name
                                         select item;
            return list.SingleOrDefault(); // if value exists return it else return NULL
            // since the return type of GetById is Employee(single value) and list is of type IEnumerable<Employee> hence list.SingleOrDefault();
        }

        public bool Update(Employee entity)
        {
            var emp = GetById(entity.EmpId);
            if (emp != null)
            {
                emp.Email = entity.Email;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
