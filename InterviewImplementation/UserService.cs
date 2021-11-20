using AutoMapper;
using DbEntities.DBContext;
using InterviewContracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewImplementation
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly InterviewQuestionsDbContext _context;
        public UserService(IMapper mapper, InterviewQuestionsDbContext context) : base(mapper)
        {
            this._context = context;
        }
        public async Task<Guid> CreateAsync(ApplicationUserModel entity)
        {
            var user = new IdentityUser
            {
                UserName = entity.Email,
                Email = entity.Email,

            };
            await this._context.AddAsync(user);
            await this._context.SaveChangesAsync();
            return Guid.Parse(user.Id);
        }

        public async Task DeleteAsync(ApplicationUserModel entity)
        {
            var user = this._autoMapper.Map<IdentityUser>(entity);
            this._context.Users.Remove(user);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await this._context.Users.FindAsync(id.ToString());
            if (user != null)
            {
                this._context.Users.Remove(user);
            }            
        }

        public async Task<List<ApplicationUserModel>> FindAllAsync()
        {
            var users = await this._context.Users.AsNoTracking().ToListAsync();
            var applicationUserModels = this._autoMapper.Map<List<ApplicationUserModel>>(users);
            return applicationUserModels;
        }

        public async Task<ApplicationUserModel> ReadAsync(Guid id)
        {
            var user = await this._context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id.ToString());
            var userApplicationModel = this._autoMapper.Map<ApplicationUserModel>(user);
            return userApplicationModel;
        }

        public async Task UpdateAsync(ApplicationUserModel entity)
        {
            var user = await this._context.Users.FindAsync(entity);
            if (user != null)
            {
                var dbEntity = this._autoMapper.Map<ApplicationUserModel>(entity);
                this._context.Update(dbEntity);
            }
        }
    }
}
