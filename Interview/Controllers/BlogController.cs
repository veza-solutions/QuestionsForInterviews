using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult AllArticles()
        {
            return View();
        }
    }
}
