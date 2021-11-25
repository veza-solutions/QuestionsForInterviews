using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities.Entities
{
    public class DeveloperRank
    {
        public DeveloperRank()
        {
            this.QuestionAnswers = new List<QuestionAnswer>();
            this.Questions = new List<Question>();
            this.Tests = new List<Test>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string RankName { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
