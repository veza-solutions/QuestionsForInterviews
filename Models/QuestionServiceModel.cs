using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionServiceModel
    {

        public Guid Id { get; set; }

        public string Description { get; set; }

        public int TimeToAnswer { get; set; }

        public virtual ICollection<QuestionAnswerServiceModel> AnswerOptions { get; set; }

        public virtual ICollection<TestServiceModel> Tests { get; set; }
        public string Answer { get; set; }
    }
}
