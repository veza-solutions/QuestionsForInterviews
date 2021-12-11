using AutoMapper;
using Interview.Models.Questions;
using InterviewContracts;
using InterviewImplementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private readonly IAnswerService _answerService;
        public QuestionsController(IQuestionService questionService, IMapper mapper, IAnswerService answerService)
        {            
            this._questionService = questionService;
            this._mapper = mapper;
            this._answerService = answerService;
        }
        public IActionResult Add()
        {
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

                //Question Answers
                var questionAnswers = WebHelpers.CreateQuestionAnswers(model.FirstAnswer, model.SecondAnswer, model.ThirdAnswer, model.Answer, id, model.DeveloperRankId);
                foreach (var item in questionAnswers)
                {
                    await this._answerService.CreateAsync(item);
                }
                
                return RedirectToAction("MakeTest", "Test");
            }
            catch (System.Exception e)
            {
                var exMsg = e.Message;                
                return RedirectToAction("Render", "Error", exMsg);
            }
            
        }
    }
}
