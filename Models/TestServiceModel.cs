using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestServiceModel
    {
        public TestServiceModel()
        {
            this.Questions = new List<QuestionServiceModel>();
            this.Answers = new List<QuestionAnswerServiceModel>();
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public ApplicationUserModel User { get; set; }

        public ICollection<QuestionServiceModel> Questions { get; set; }

        public ICollection<QuestionAnswerServiceModel> Answers { get; set; }
    }
}
