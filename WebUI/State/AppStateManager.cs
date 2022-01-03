using System;
using System.Collections.Generic;
using WebUI.Entities.Models;

namespace WebUI
{
  public class AppStateManager{

    public List<Question> questions=new List<Question>();
    public User user { get; set; }
    public Content Content { get; set; }
    public AppStateManager()
    {
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
      questions.Add(new Question(){Options=new List<Option>(){new Option(),new Option(),new Option(),new Option()}});
        
    }

  // public event Action<Question,int> State;
  // public List<Question> questions { get; set; }

  public void UpdateQuestion(Question question,int index){
    
    if(questions.Capacity<=index){
      questions.Add(new Question(){});
    }
    questions[index]=question;
  }
  public void UpdateQuestionOption(int QuestionIndex,int OptionIndex,string value){
  
    questions[QuestionIndex].Options[OptionIndex].Value=value;
  }




  }
    
}
