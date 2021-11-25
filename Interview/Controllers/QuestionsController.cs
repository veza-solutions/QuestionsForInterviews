using DbEntities.DBContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Interview.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly InterviewQuestionsDbContext _dbContext;

        public QuestionsController(InterviewQuestionsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public IActionResult Add()
        {
            if (this._dbContext.DeveloperRanks.ToList().Count == 0)
            {
                ServiceConstants.Seeder.AddDeveloperRankings(this._dbContext);
            }
            
            return View();
        }
    }
}
