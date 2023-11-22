using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// converting this class into a table to store data
// this class is an exact copy of Departments table in SQLQuery3.sql file
namespace EmpMgmtDAL.EntityLayer
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // tinyint in sql = byte in c#
        public byte DeptId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // one department will have a list of employees
        // virtual keyword allows the property to be overridden in derived classes
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
