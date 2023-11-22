using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// used to interact with a database
using Microsoft.EntityFrameworkCore;
namespace EmpMgmtDAL.EntityLayer
{
    // DbContext: a class that represents a session with the database and provides APIs for querying and updating data.
    public class EmpMgmtDbContext : DbContext
    {
        // sets up a connection between database and ui by initializing an instance of the EmpMgmtDbContext class with a set of options that specify how to connect to the database
        // we have to inject this dbcontext(EmpMgmtDAL) into the ui layer(EmpMgmtUI) for querying and updating
        public EmpMgmtDbContext(DbContextOptions<EmpMgmtDbContext> options) : base(options)
        {

        }
        // DbSet provides APIs for querying, adding, updating, and deleting entities in the underlying database table.
        // DbSet provides LINQ-based query methods such as Where, OrderBy, and Skip/Take.
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Employee> Employees { get; set; }

        // OnModelCreating is a method inherited from DbContext which is overriden 
        // adds some initial data to the database when it is created for the first time.
        // this code ensures that the database will always have some data in it when it is first created, which can be useful for testing and development purposes.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // The HasData method is used to define the data to be added through an array of objects
            // modelBuilder.Entity<Department>() an instance of the Department class for configuring the Department table
            modelBuilder.Entity<Department>()
                    .HasData(new Department { DeptId = 1, Name = "Dept1" }, new Department { DeptId = 2, Name = "Dept2" });
            modelBuilder.Entity<Grade>().HasData(new Grade { GradeId = 1, Name = "E1", Basic = 15000, HRA = 20, TA = 12 },
                    new Grade { GradeId = 2, Name = "E2", Basic = 12000, HRA = 15, TA = 10 });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmpId = 1,
                Name = "UEmp",
                DOB = new DateTime(1999, 1, 1),
                Email = "uemp@mail.com",
                DeptId = 1,
                GradeId = 1,
                Gender = "M",
                Status = 1,
                Password = "pass123"
            },
             new Employee
             {
                 EmpId = 2,
                 Name = "OEmp",
                 DOB = new DateTime(2000, 1, 1),
                 Email = "0emp@mail.com",
                 DeptId = 2,
                 GradeId = 2,
                 Gender = "F",
                 Status = 1,
                 Password = "pass123"
             });
            base.OnModelCreating(modelBuilder);
        }
    }


}
