using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Service.Services
{
    public class BaseService
    {
        internal void Validate<T>(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Objeto Inv�lido!");

            validator.ValidateAndThrow(obj);
        }
    }
}
