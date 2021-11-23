using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewContracts
{
    public interface IUserService : IServiceBase<ApplicationUserModel>
    {
        public Task<ApplicationUserModel> GetUserById(string id);
        public Task<ApplicationUserModel> GetUserByEmail(string email);

        public Task<bool> IsUserRegistered(string email);
    }
}
