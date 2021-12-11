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
        public IActionResult GenerateTest(GetTestProperties getTest)
        {
            if (getTest.Language != null && getTest.Rank != null && getTest.Questions != null)
            {
                return Ok(new { language = "hahaah", rank = "Junior", questions = 15 });
            }
            return BadRequest();
        }
    }
}
