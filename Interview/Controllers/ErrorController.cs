using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Render(string msg)
        {
            if (msg == null)
            {
                return View();
            }
            return View(msg);
        }
    }
}
