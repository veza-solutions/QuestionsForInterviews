using DbEntities.DBContext;
using DbEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConstants
{
    public static class Seeder
    {
        public static void AddDeveloperRankings(InterviewQuestionsDbContext dbContext)
        {
            var developers = new List<DeveloperRank> 
            { 
                new DeveloperRank
                {
                    Id = Guid.NewGuid(),
                    RankName = "Intern"
                },
                new DeveloperRank
                {
                    Id = Guid.NewGuid(),
                    RankName = "Junior"
                },
                new DeveloperRank
                {
                    Id = Guid.NewGuid(),
                    RankName = "Mid level"
                },
                new DeveloperRank
                {
                    Id = Guid.NewGuid(),
                    RankName = "Senior"
                },
            };

            dbContext.DeveloperRanks.AddRange(developers);
            dbContext.SaveChanges();
        }
            
            
        
    }
}
