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
    public class TestService : ServiceBase,ITestService
    {
        private readonly InterviewQuestionsDbContext _context;
        public TestService(IMapper mapper, InterviewQuestionsDbContext context) : base(mapper)
        {
            this._context = context;
        }

        public async Task<Guid> CreateAsync(TestServiceModel entity)
        {
            var test = this._autoMapper.Map<Test>(entity);
            this._context.Tests.Add(test);
            await this._context.SaveChangesAsync();
            return test.Id;
        }

        public async Task DeleteAsync(TestServiceModel entity)
        {
            var test = this._autoMapper.Map<Test>(entity);
            this._context.Tests.Remove(test);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dbtest = await this._context.Tests.FindAsync(id);
            if (dbtest != null)
            {
                this._context.Tests.Remove(dbtest);
                await this._context.SaveChangesAsync();
            }
        }

        public async Task<List<TestServiceModel>> FindAllAsync()
        {
            var tests = await this._context.Tests.AsNoTracking().ToListAsync();
            var testsServiceModels = this._autoMapper.Map<List<TestServiceModel>>(tests);
            return await Task.FromResult(testsServiceModels);
        }

        public async Task<TestServiceModel> ReadAsync(Guid id)
        {
            var tests = await this._context.Tests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var testsServiceModels = this._autoMapper.Map<TestServiceModel>(tests);
            return testsServiceModels;
        }

        public async Task UpdateAsync(TestServiceModel entity)
        {
            var test = await this._context.QuestionAnswers.FindAsync(entity.Id);
            if (test != null)
            {
                var dbEntity = this._autoMapper.Map<Test>(entity);
                this._context.Update(dbEntity);
            }
        }
    }
}
