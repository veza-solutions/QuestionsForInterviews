using Interview.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class TestController : Controller
    {
        public IActionResult MakeTest()
        {
            var model = new GenerateTestViewModel();
            return View(model);
        }
    }
}
