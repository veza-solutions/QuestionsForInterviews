using Interview.Models.Test;
using InterviewContracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Interview.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            this._testService = testService;
        }
        public IActionResult MakeTest()
        {
            var model = new GenerateTestViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult GenerateTest(string language, string rank, string questions)
        {
            if (language != null && rank != null && questions != null)
            {
                var test = this._testService.GenerateRandomTest(language, Guid.Parse(rank), int.Parse(questions));
                return Ok(new { questions = test.Questions });
            }
            return BadRequest();
        }
    }
}
