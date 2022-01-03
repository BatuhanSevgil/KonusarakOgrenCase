using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete.Dto
{
   public class AuthDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
