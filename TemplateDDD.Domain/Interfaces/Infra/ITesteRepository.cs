using TemplateDDD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateDDD.Domain.Interfaces.Infra
{
    public interface ITesteRepository
    {
        int Insert(Teste sample);
        Teste GetById(int id);
        bool Update(Teste model);
        bool Delete(int id);
    }
}
