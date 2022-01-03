using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Dto
{
    public class QuizDto:IDto
    {

        public Quiz quiz { get; set; }
        public List<Question>  questions{ get; set; }
        public List<Option> options { get; set; }


    }
}
