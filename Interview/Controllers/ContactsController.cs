using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
