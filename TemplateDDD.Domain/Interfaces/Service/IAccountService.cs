using TemplateDDD.Domain.Models;
using TemplateDDD.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateDDD.Domain.ViewModel;

namespace TemplateDDD.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        object Login(LoginAccountCommand sample);
    }
}
