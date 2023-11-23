using EmpMgmtDAL.EntityLayer;
using EmpMgmtDAL;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmtUI.Controllers
{
    public class ManageEmployeeController : Controller
    {
        IRepository<Employee> employeeRepository;
        // IRepository<Employee> is visible here because it is being injected in ConfigureServices method in the startup file
        public ManageEmployeeController(IRepository<Employee> repository)
        {
            employeeRepository = repository;
        }
        public IActionResult Index()
        {
            var emplist = employeeRepository.GetAll();
            return View(emplist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewModels.NewEmployeeVM vm = new ViewModels.NewEmployeeVM();
            return View(vm);
        }

        [HttpPost]
        // The create page will bind all the entered data into the viewmodel(NewEmployeeVM) and send it here through post
        public IActionResult Create(ViewModels.NewEmployeeVM vm)
        {
            if(ModelState.IsValid) // validating all the entered data
            {
                // converting the vm class into entity so as to store it in db
                // EmpMgmtDAL.EntityLayer.Employee is visible since it is being added in the Dependencies/Projects folder
                Employee employee = new Employee();
                employee.Name = vm.Name;
                employee.Email = vm.Email;
                employee.Gender = vm.Gender;
                employee.DeptId = vm.DeptId;
                employee.GradeId = (byte)vm.GradeId;
                employee.Password = vm.Password;
                employee.DOB = vm.DOB;
                employee.Status = 1;
                if (employeeRepository.Add(employee))
                    return RedirectToAction("Index");
                else
                    return View();
            }
            else
            {
                return View(vm); // return the same view to show the error msg
            }
      
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
