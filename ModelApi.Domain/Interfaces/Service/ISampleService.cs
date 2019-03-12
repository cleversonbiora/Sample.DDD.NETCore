using ModelApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelApi.Domain.Interfaces.Service
{
    public interface ISampleService
    { 
        int Get();
        int Post(Sample sample);
    }
}
