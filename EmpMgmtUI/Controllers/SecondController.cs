using Microsoft.AspNetCore.Mvc;

namespace EmpMgmtUI.Controllers
{
    public class SecondController : Controller
    {
        public string Index()
        {
            return "Second controller index called";
        }

        public string Pagination(int maxval = 10, int minval = 1, string sort = "")
        {
            return "Pagination called ";
        }
    }
}
