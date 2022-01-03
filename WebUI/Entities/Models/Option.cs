    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Entities.Models
{
    public class Option
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public int QuestionId { get; set; }
        public string Value { get; set; }
        public bool isCorrect { get; set; }

    }
}