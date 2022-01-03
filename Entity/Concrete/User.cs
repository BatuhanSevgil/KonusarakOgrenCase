using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
 public class User:IEntity
    {
        public int Id { get; set; }
        public string LoginUser { get; set; }
        public string LoginPass { get; set; }
        public string Title { get; set; }


        public List<Quiz> Quizzes { get; set; }


    }
}
