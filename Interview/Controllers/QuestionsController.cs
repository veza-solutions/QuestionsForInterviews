using AutoMapper;
using Interview.Models.Questions;
using InterviewContracts;
using InterviewImplementation;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {            
            this._questionService = questionService;
            this._mapper = mapper;
        }
        public IActionResult Add()
        {
            //Add in service DeveloperRanks DO NOT USE CONTEXT IN WEB

            //if (this._dbContext.DeveloperRanks.ToList().Count == 0)
            //{
            //    ServiceConstants.Seeder.AddDeveloperRankings(this._dbContext);
            //}
            
            return View();
        }

        public IActionResult AddQuestionAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestionAdmin(AddQuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var questionDbModel = this._mapper.Map<QuestionServiceModel>(model);
                questionDbModel.Id = Guid.NewGuid();
                var id = await this._questionService.CreateAsync(questionDbModel);
                return RedirectToAction("MakeTest", "Test");
            }
            catch (System.Exception e)
            {
                var exMsg = e.Message;
                return RedirectToAction("Render", "Error", exMsg);
            }
            return View();
        }
    }
}
