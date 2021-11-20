using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities.Entities
{
    public class Question
    {
        public Question()
        {
            this.AnswerOptions = new HashSet<QuestionAnswer>();
            this.Tests = new HashSet<Test>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        [Required]
        [Range(10, 60)]
        public int TimeToAnswer { get; set; }

        public virtual ICollection<QuestionAnswer> AnswerOptions { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
