using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class QuestionsController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
