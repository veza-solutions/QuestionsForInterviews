using System;

namespace Interview.Models.Questions
{
    public class AddQuestionViewModel
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public int TimeToAnswer { get; set; }

        public string Answer { get; set; }

        public string FirstAnswer { get; set; }

        public string SecondAnswer { get; set; }

        public string ThirdAnswer { get; set; }

        public Guid DeveloperRankId { get; set; }
    }
}
