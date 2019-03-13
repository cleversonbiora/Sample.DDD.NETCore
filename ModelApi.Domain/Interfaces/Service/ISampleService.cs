using ModelApi.Domain.Models;
using ModelApi.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelApi.Domain.Interfaces.Service
{
    public interface ISampleService
    {
        Sample Get();
        int Post(InsertSampleCommand sample);
    }
}
