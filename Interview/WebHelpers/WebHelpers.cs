using Models;
using System;
using System.Collections.Generic;

namespace Interview
{
    public static class WebHelpers
    {
        public static List<QuestionAnswerServiceModel> CreateQuestionAnswers(string firstQuestion, string secondQuestion, string thirdQuestion, string fourthQuestion, Guid questionId, Guid developerId)
        {
            var questionAnswers = new List<QuestionAnswerServiceModel>();

            var questionFirstAnswerServiceModel = new QuestionAnswerServiceModel
            {
                Id = Guid.NewGuid(),
                Description = firstQuestion,
                QuestionId = questionId,
                DeveloperRankId = developerId
            };
            questionAnswers.Add(questionFirstAnswerServiceModel);
            var questionSecondAnswerServiceModel = new QuestionAnswerServiceModel
            {
                Id = Guid.NewGuid(),
                Description = secondQuestion,
                QuestionId = questionId,
                DeveloperRankId = developerId
            };
            questionAnswers.Add(questionSecondAnswerServiceModel);
            var questionThirdAnswerServiceModel = new QuestionAnswerServiceModel
            {
                Id = Guid.NewGuid(),
                Description = thirdQuestion,
                QuestionId = questionId,
                DeveloperRankId = developerId
            };
            questionAnswers.Add(questionThirdAnswerServiceModel);
            var questionFourthAnswerServiceModel = new QuestionAnswerServiceModel
            {
                Id = Guid.NewGuid(),
                Description = fourthQuestion,
                QuestionId = questionId,
                DeveloperRankId = developerId
            };
            questionAnswers.Add(questionFourthAnswerServiceModel);

            return questionAnswers;
        }
    }
}
