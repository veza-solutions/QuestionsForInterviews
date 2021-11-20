using DbEntities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbEntities.DBContext
{
    public class InterviewQuestionsDbContext : IdentityDbContext
    {
        public InterviewQuestionsDbContext()
        {

        }

        public InterviewQuestionsDbContext(DbContextOptions<InterviewQuestionsDbContext> options) : base(options)
        {

        }
        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "Server=LAPTOP-LLA2HTBF\\SQLEXPRESS;Database=InterviewQuestions;Trusted_Connection=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(conn);
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
