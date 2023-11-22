using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// this class is an exact copy of Grade table in SQLQuery3.sql file

namespace EmpMgmtDAL.EntityLayer
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte GradeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Basic { get; set; }
        [Required]
        public byte TA { get; set; }
        [Required]
        public byte HRA { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
