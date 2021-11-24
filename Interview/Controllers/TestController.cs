using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class TestController : Controller
    {
        public IActionResult MakeTest()
        {
            return View();
        }
    }
}
