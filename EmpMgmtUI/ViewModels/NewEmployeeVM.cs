using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmpMgmtUI.ViewModels
{
    public class NewEmployeeVM
    {
        public NewEmployeeVM()
        {
            // Dummy data
            Grades = new List<Grade>
            {
                new Grade{ GradeId=1,Name="E1"},
                new Grade{ GradeId=2,Name="E2"}
            };
            Departments = new List<Department>
            {
                new Department{ DeptId=-1, Name="Select Dept"},
                new Department{ DeptId=1, Name="Dept1"},
                new Department{ DeptId=2, Name="Dept2"},
                new Department{ DeptId=3, Name="Dept3"}
            };
        }
        public int EmpId { get; set; }

        // Validation on name field
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is a required field")]
        [StringLength(50, ErrorMessage = "Name cannot exceed above 50 chars")]
        [MinLength(3, ErrorMessage = "Name should be 3 chars")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "DOB is a required field")]
        public DateTime DOB { get; set; }
        // This property may be null
        public DateTime? DOJ { get; set; }
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Department is a required field")]
        public byte DeptId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Grade is a required field")]
        public int GradeId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is a required field")]
        [RegularExpression(@"\w+@\w+\.\w{2,3}", ErrorMessage = "Email id format is invalid")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is a required field")]
        public string Password { get; set; }
        // The below 2 properties render a dropdown in the UI
        public List<Grade> Grades { get; set; }
        public List<Department> Departments { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        public string Name { get; set; }
    }
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
    }
}
