using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Domain.Commands.Sample
{
    public class RegisterAccountCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
