using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities.Entities
{
    public class QuestionAnswer
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Description { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public Guid DeveloperRankId { get; set; }

        public virtual DeveloperRank DeveloperRank { get; set; }
    }
}
