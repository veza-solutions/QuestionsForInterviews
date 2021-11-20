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
    public class AnswerService : ServiceBase, IAnswerService
    {
        private readonly InterviewQuestionsDbContext _context;

        public AnswerService(IMapper mapper, InterviewQuestionsDbContext context) : base(mapper)
        {
            this._context = context;
        }

        public async Task<Guid> CreateAsync(QuestionAnswerServiceModel entity)
        {
            var questionDbModel = this._autoMapper.Map<QuestionAnswer>(entity);
            this._context.QuestionAnswers.Add(questionDbModel);
            await this._context.SaveChangesAsync();
            return questionDbModel.Id;
        }

        public async Task DeleteAsync(QuestionAnswerServiceModel entity)
        {
            var questionDbModel = this._autoMapper.Map<QuestionAnswer>(entity);
            this._context.QuestionAnswers.Remove(questionDbModel);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbAnswer = await this._context.QuestionAnswers.FindAsync(id);
            if (dbAnswer != null)
            {
                this._context.QuestionAnswers.Remove(dbAnswer);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<List<QuestionAnswerServiceModel>> FindAllAsync()
        {
            var questionAnswers = await this._context.QuestionAnswers.AsNoTracking().ToListAsync();
            var questionsServiceModels = this._autoMapper.Map<List<QuestionAnswerServiceModel>>(questionAnswers);
            return await Task.FromResult(questionsServiceModels);
        }

        public async Task<QuestionAnswerServiceModel> ReadAsync(Guid id)
        {
            var questionAnswer = await this._context.QuestionAnswers.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
            var questionAnswerServiceModel = this._autoMapper.Map<QuestionAnswerServiceModel>(questionAnswer);
            return questionAnswerServiceModel;
        }

        public async Task UpdateAsync(QuestionAnswerServiceModel entity)
        {            
            var questionAnswer = await this._context.QuestionAnswers.FindAsync(entity.Id);
            if (questionAnswer != null)
            {
                var dbEntity = this._autoMapper.Map<QuestionAnswer>(entity);
                this._context.Update(dbEntity);
            }            
        }
    }
}
