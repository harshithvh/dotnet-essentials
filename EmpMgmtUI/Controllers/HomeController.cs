using Microsoft.AspNetCore.Mvc;
using System;
using EmpMgmtUI.GreetingCode;

namespace EmpMgmtUI.Controllers
{
    // Controller is an inbuilt class from Microsoft.AspNetCore.Mvc
    // [Route("[controller]")] sets to default (/home)
    [Route("myhome/ceridian")]
    public class HomeController : Controller
    {
        Greetings greet;
        public HomeController()
        {
            greet = new Greetings();
        }
        [Route("MyIndex")]
        public string Index()
        {
            return "Index called";
        }

        [Route("MyCreate")]
        public string Create()
        {
            return "Create called";
        }

        [Route("MyEdit")]
        public string Edit(string id = "0")
        {
            id = Request.Query["empid"];
            string name = Request.Query["name"];
            return "Edit called " + id + " " + name;
        }

        public string Delete()
        {
            return "Delete called";
        }

        // Since the return type is view this method has to render a html page
        // the name of this method must match the filename under Views/Home
        [Route("Greetings/{name?}")]
        public ViewResult Greetings(string name = "")
        {
            // Ways of passing data from controller to view

            //ViewData["EmpName"] = name;
            //ViewData["DOB"] = new DateTime(1999, 2, 4);
            //ViewData["Salary"] = 23422.2;

            //ViewBag.Name = name;
            //ViewBag.DOB = new DateTime(1999, 2, 4);
            //ViewBag.Salary = 13213.3;

            Models.MyEmployee employee = new Models.MyEmployee();
            employee.Name = name;
            employee.DOB = new DateTime(1999, 2, 4);
            employee.Salary = 222.3;
            ViewBag.Employee = employee;

            return View();
        }

        [Route("Greetings2")]
        public ViewResult GreetingInjection()
        {
            var grtmsg = greet.GeetingMessage();
            ViewBag.Message = grtmsg;
            return View();
        }
    }
}