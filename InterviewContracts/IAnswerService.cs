using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewContracts
{
    public interface IAnswerService : IServiceBase<QuestionAnswerServiceModel>
    {
        Task AddRange(List<QuestionAnswerServiceModel> answers);
    }
}
