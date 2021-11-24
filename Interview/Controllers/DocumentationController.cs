using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
