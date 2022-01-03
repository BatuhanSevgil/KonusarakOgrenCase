using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Concrete
{
    public class Quiz:IEntity
    {
        public int Id { get; set; }
        public string Session { get; set; }
        
        public int ContentId { get; set; }
        public int UserId { get; set; }

        public Content Content { get; set; }
        public List<Question> questions { get; set; }
        public User User { get; set; }


    }
}
