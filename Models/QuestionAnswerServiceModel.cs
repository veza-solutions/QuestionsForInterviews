using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuestionAnswerServiceModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid QuestionId { get; set; }

        public QuestionServiceModel Question { get; set; }
    }
}
