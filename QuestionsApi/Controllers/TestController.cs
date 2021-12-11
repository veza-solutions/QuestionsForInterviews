using Microsoft.AspNetCore.Mvc;

namespace QuestionsApi.Controllers
{
    [ApiController]
    [Route("Test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("MakeTest")]
        public ActionResult MakeTest(string language, string rank, string questions)
        {
            if(language != null && rank != null && questions != null)
            {
                return Ok(new { language="hahaah", rank="Junior",questions=15 });
            }
            return BadRequest();
        } 
    }
}
