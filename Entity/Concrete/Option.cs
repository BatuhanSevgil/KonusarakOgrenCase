using Core.Entity;

namespace Entity.Concrete
{
    public class Option : IEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
        public string Value { get; set; }
        public bool isCorrect { get; set; }

        public Question Question { get; set; }

    }
}
