using FluentValidation;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelApi.Service.Services
{
    public class SampleService : ISampleService
    {
        public int Get()
        {
            return 1;
        }
        public int Post(Sample sample) //: AbstractValidator<Sample>
        {
            return 1;
        }
    }
}
