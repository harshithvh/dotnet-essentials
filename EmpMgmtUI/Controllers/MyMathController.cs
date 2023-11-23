using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpMgmtUI.Controllers
{
    public class MyMathController : Controller
    {
        // IActionResult allows you to return a variety of result types from an action method, such as ViewResult, JsonResult, FileResult, RedirectResult, etc.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessMath()
        {
            string n1 = Request.Form["Num1"];
            string n2 = Request.Form["Num2"];

            string opr = Request.Form["opr"];
            string operation = "";

            int num1 = Convert.ToInt32(n1);
            int num2 = Convert.ToInt32(n2);

            int result = 0;

            if (opr == "1")
            {
                result = num1 + num2;
                operation = "Add";

            }
            else if (opr == "2")
            {
                if (num1 < num2)
                {
                    //show error
                    ViewBag.IsError = true;
                    ViewBag.Message = "Cannot subtract and it gives negative value";
                    return View();
                }
                else
                {
                    result = num1 - num2;
                    operation = "Subtract";
                }
            }

            // To send data from one action to another
            TempData["Operation"] = operation;
            TempData["Result"] = result;

            return RedirectToAction("ShowResult");
        }

        public IActionResult ShowResult()
        {
            ViewBag.Operation = TempData["Operation"];
            ViewBag.Result = TempData["Result"];
            return View();
        }
    }
}
