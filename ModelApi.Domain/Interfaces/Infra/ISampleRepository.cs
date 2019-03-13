using ModelApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelApi.Domain.Interfaces.Infra
{
    public interface ISampleRepository
    {
        int Insert(Sample sample);
        Sample GetById(int id);
    }
}
