using TemplateDDD.Domain.Models;
using TemplateDDD.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateDDD.Domain.ViewModel;

namespace TemplateDDD.Domain.Interfaces.Service
{
    public interface ISampleService
    {
        SampleViewModel Get(int id);
        int Post(InsertSampleCommand sample);
        bool Put(UpdateSampleCommand sample);
        bool Delete(int id);
    }
}
