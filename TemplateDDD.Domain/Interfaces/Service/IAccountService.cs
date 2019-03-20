using TemplateDDD.Domain.Models;
using TemplateDDD.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateDDD.Domain.ViewModel;
using System.Threading.Tasks;

namespace TemplateDDD.Domain.Interfaces.Service
{
    public interface IAccountService
    {
        Task<object> Login(LoginAccountCommand sample);
        Task<object> Register(RegisterAccountCommand sample);
    }
}
