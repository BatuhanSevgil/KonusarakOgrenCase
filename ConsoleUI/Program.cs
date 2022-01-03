using System;
using DataAccess.Concrete.EntityFramework;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Entity.Concrete;
using System.Collections.Generic;
using Business.Concrete;

namespace ConsoleUI
{
  public class Program
  {


    static void Main(string[] args)
    {

      using (var context = new QuizContext())
      {


        var userDemo = context.User.Where(item => item.LoginUser == "demo").FirstOrDefault();
        if (userDemo == null)
        {
          var user = new User() { LoginPass = "demo", LoginUser = "demo", Title = "Demo User" };
          user.ToJson();
          var entity = context.Entry(user);
          entity.State = EntityState.Added;
          context.SaveChanges();

        }
        userDemo = context.User.Where(item => item.LoginUser == "demo").FirstOrDefault();
        var sampleContent = new Content()
        {
          Description = "[Demo init] Like every other aspect of our society, how we handle death and dying needs to change in the face of climate change. This method may be a path forward.",
          Title = "[DEMO init]How Body Farms and Human Composting Can Help Communities",
          Detail = "[Demo init] detail",
          PublishContentDate = DateTime.Parse("2022 - 01 - 02 22:00:31"),
          PublishRssDate = DateTime.Parse("2022-01-02 14:00:00")
        };
        var sampleContentCheck = context.Content.Where(item => item.Title == sampleContent.Title).FirstOrDefault();
        if (sampleContentCheck == null)
        {

          var sampleEntity = context.Entry(sampleContent);
          sampleEntity.State = EntityState.Added;
          context.SaveChanges();
        }

        sampleContentCheck = context.Content.Where(item => item.Title == sampleContent.Title).FirstOrDefault();
        var contentManager = new ContentManager(new EfContentDal()).SyncContentWithWired();
        var sampleQuiz = new Quiz()
        {
          ContentId = sampleContentCheck.Id,
          UserId = userDemo.Id,
          Session = "[Demo]"
        };

        var sampleQuizCheck = context.Quiz.Where(item => item.Session == "[Demo]").FirstOrDefault();
        if (sampleQuizCheck == null)
        {

          var quizEntity = context.Entry(sampleQuiz);
          quizEntity.State = EntityState.Added;
          context.SaveChanges();
        }
        sampleQuizCheck = context.Quiz.Where(item => item.Session == "[Demo]").FirstOrDefault();

        var checkQuestions = context.Question.Where(item => item.QuizId == sampleQuizCheck.Id).ToList();
        if (checkQuestions == null || checkQuestions.Count == 0)
        {
          var questions = new List<Question>(){
          new Question(){ContentId=sampleQuizCheck.ContentId,QuestionText="2+2",UserId=userDemo.Id,Order=0,QuizId=sampleQuizCheck.Id}, new Question(){ContentId=sampleQuizCheck.ContentId,QuestionText="4+4",UserId=userDemo.Id,Order=1,QuizId=sampleQuizCheck.Id}, new Question(){ContentId=sampleQuizCheck.ContentId,QuestionText="6+2",UserId=userDemo.Id,Order=2,QuizId=sampleQuizCheck.Id}, new Question(){ContentId=sampleQuizCheck.ContentId,QuestionText="10+10",UserId=userDemo.Id,Order=3,QuizId=sampleQuizCheck.Id}
        };
          foreach (var question in questions)
          {
            var questionEntity = context.Entry(question);
            questionEntity.State = EntityState.Added;
            context.SaveChanges();
          }

          questions = context.Question.Where(item => item.QuizId == sampleQuizCheck.Id).ToList();
          var options = new List<Option>(){
            //question
            new Option(){Order=0,QuestionId=questions[0].Id,Value="3",isCorrect=false},
            new Option(){Order=1,QuestionId=questions[0].Id,Value="6",isCorrect=false},
            new Option(){Order=2,QuestionId=questions[0].Id,Value="4",isCorrect=true},
            new Option(){Order=3,QuestionId=questions[0].Id,Value="9",isCorrect=false},
            //question
            new Option(){Order=0,QuestionId=questions[1].Id,Value="8",isCorrect=true},
            new Option(){Order=1,QuestionId=questions[1].Id,Value="12",isCorrect=false},
            new Option(){Order=2,QuestionId=questions[1].Id,Value="3",isCorrect=false},
            new Option(){Order=3,QuestionId=questions[1].Id,Value="1",isCorrect=false},
            //question
            new Option(){Order=0,QuestionId=questions[2].Id,Value="12",isCorrect=false},
            new Option(){Order=1,QuestionId=questions[2].Id,Value="8",isCorrect=true},
            new Option(){Order=2,QuestionId=questions[2].Id,Value="25",isCorrect=false},
            new Option(){Order=3,QuestionId=questions[2].Id,Value="123",isCorrect=false},
            //question
            new Option(){Order=0,QuestionId=questions[3].Id,Value="12",isCorrect=false},
            new Option(){Order=1,QuestionId=questions[3].Id,Value="8",isCorrect=false},
            new Option(){Order=2,QuestionId=questions[3].Id,Value="20",isCorrect=true},
            new Option(){Order=3,QuestionId=questions[3].Id,Value="123",isCorrect=false},

          };

          foreach (var option in options)
          {
            var optionEntity = context.Entry(option);
            optionEntity.State = EntityState.Added;
            context.SaveChanges();
          }


        }





      }


    }

  }


}