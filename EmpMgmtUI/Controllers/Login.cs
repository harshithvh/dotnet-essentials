// Made for testing by EmpMgmtTest
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmtUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // since this is used for testing no view/route(home/index) has been made
        public IActionResult Index(Models.LoginData login)
        {
            if (login.UserName == "user" && login.Password == "aspmvc")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.InvalidLogin = true;
                return View(); // return to the same view
            }

        }
    }
}
