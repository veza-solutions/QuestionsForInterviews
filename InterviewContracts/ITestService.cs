using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewContracts
{
    public interface ITestService : IServiceBase<TestServiceModel>
    {
        TestServiceModel GenerateRandomTest(string language, Guid level, int numberOfQuestions);
    }
}
