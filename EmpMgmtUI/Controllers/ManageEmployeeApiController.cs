using EmpMgmtDAL.EntityLayer;
using EmpMgmtDAL;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// test this api in postman by first running the server(f5)
namespace EmpMgmtUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageEmployeeApiController : ControllerBase
    {
        IRepository<Employee> employeeRepository;
        public ManageEmployeeApiController(IRepository<Employee> empRepo)
        {
            employeeRepository = empRepo;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult Get()
        {
            var list = employeeRepository.GetAll();

            // converting into an anonymous object with only the required properties to be sent
            // it is recommended to send as json objects rather than the entity(Employee object) itself
            var dtoemp = list.Select(emp => new
            {
                EmpId = emp.EmpId,
                Name = emp.Name,
                BirthDate = emp.DOB,
                Gender = emp.Gender == "M" ? "Male" : "Female",
                DeptName = emp.Department.Name,
                Grade = emp.Grade.Name,
                Email = emp.Email
            });

            return Ok(dtoemp);
        }

        [HttpGet]
        [Route("FindEmployees/{name?}")]
        public IActionResult Find(string name = "")
        {
            var list = employeeRepository.Find(name);

            if (list == null)
            {
                return NotFound(new { message = "No employees found for " + name });
            }
            else
            {
                var dtoemp = list.Select(emp => new
                {
                    EmpId = emp.EmpId,
                    Name = emp.Name,
                    BirthDate = emp.DOB,
                    Gender = emp.Gender == "M" ? "Male" : "Female",
                    DeptName = emp.Department.Name,
                    Grade = emp.Grade.Name,
                    Email = emp.Email
                });

                return Ok(dtoemp);
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Add([FromBody] Employee emp)
        {

            bool ret = employeeRepository.Add(emp);
            if (ret)
            {
                // returns an HTTP 201 Created response with a CreatedAtAction result that specifies the GetById action method of the ManageEmployeeApi controller to retrieve the newly created resource(emp)
                return CreatedAtAction("GetById", "ManageEmployeeApi", emp);
            }
            else
                return StatusCode(500, new { message = "Cannot add employee" });
        }

    }
}
