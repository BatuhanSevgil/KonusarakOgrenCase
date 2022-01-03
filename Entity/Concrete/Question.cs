using Core.Entity;
using System.Collections.Generic;

namespace Entity.Concrete
{
    public class Question:IEntity
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int ContentId { get; set; }
        public int Order { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }

        public List<Option> Options { get; set; }

        public User User { get; set; }
        public Content Content { get; set; }
        public Quiz Quiz { get; set; }


    }
}
