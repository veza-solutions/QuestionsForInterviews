using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities.Entities
{
    public class Test
    {
        public Test()
        {
            this.Questions = new HashSet<Question>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
