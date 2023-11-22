using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class is an exact copy of Employee table in SQLQuery3.sql file

namespace EmpMgmtDAL.EntityLayer
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte EmpId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOJ { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }


        [Required]
        [ForeignKey("Department")]
        public byte DeptId { get; set; }
        [Required]
        [ForeignKey("Grade")]
        public byte GradeId { get; set; }

        public byte Status { get; set; }

        //Navigational properties
        // one employee will belong to one department and grade
        public Department Department { get; set; }
        public Grade Grade { get; set; }
    }
}
