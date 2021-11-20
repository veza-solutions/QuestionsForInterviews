using AutoMapper;
using DbEntities.DBContext;
using DbEntities.Entities;
using InterviewContracts;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewImplementation
{
    public class QuestionService : ServiceBase,IQuestionService
    {
        private readonly InterviewQuestionsDbContext _context;
        public QuestionService(IMapper mapper, InterviewQuestionsDbContext context) : base(mapper)
        {
            this._context = context;
        }

        public async Task<Guid> CreateAsync(QuestionServiceModel entity)
        {
            var questionDbModel = this._autoMapper.Map<Question>(entity);
            this._context.Questions.Add(questionDbModel);
            await this._context.SaveChangesAsync();
            return questionDbModel.Id;
        }

        public async Task DeleteAsync(QuestionServiceModel entity)
        {
            var questionDbModel = this._autoMapper.Map<Question>(entity);
            this._context.Questions.Remove(questionDbModel);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbquestion = await this._context.Questions.FindAsync(id);
            if (dbquestion != null)
            {
                this._context.Questions.Remove(dbquestion);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<List<QuestionServiceModel>> FindAllAsync()
        {
            var questions = await this._context.Questions.AsNoTracking().ToListAsync();
            var questionsServiceModels = this._autoMapper.Map<List<QuestionServiceModel>>(questions);
            return await Task.FromResult(questionsServiceModels);
        }

        public async Task<QuestionServiceModel> ReadAsync(Guid id)
        {
            var question = await this._context.Questions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var questionServiceModel = this._autoMapper.Map<QuestionServiceModel>(question);
            return questionServiceModel;
        }

        public async Task UpdateAsync(QuestionServiceModel entity)
        {
            var question = await this._context.Questions.FindAsync(entity.Id);
            if (question != null)
            {
                var dbEntity = this._autoMapper.Map<QuestionAnswer>(entity);
                this._context.Update(dbEntity);
            }
        }
    }
}
