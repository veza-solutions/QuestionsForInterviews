using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TestServiceModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public ApplicationUserModel User { get; set; }

        public virtual ICollection<QuestionServiceModel> Questions { get; set; }
    }
}
