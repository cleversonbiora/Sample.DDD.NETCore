using ModelApi.Domain.Models;
using ModelApi.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using ModelApi.Domain.ViewModel;

namespace ModelApi.Domain.Interfaces.Service
{
    public interface ISampleService
    {
        SampleViewModel Get(int id);
        int Post(InsertSampleCommand sample);
    }
}
