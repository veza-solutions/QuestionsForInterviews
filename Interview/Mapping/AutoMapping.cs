using AutoMapper;
using DbEntities.Entities;
using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<QuestionAnswer, QuestionAnswerServiceModel>();
            CreateMap<QuestionAnswerServiceModel, QuestionAnswer>();
            CreateMap<Question, QuestionServiceModel>();
            CreateMap<QuestionServiceModel, Question>();
            CreateMap<Test, TestServiceModel>();
            CreateMap<TestServiceModel, Test>();
            CreateMap<IdentityUser, ApplicationUserModel>();
            CreateMap<ApplicationUserModel, IdentityUser>();
        }
        //add mapping
        
    }
}
