using FluentValidation;
using TemplateDDD.Domain.Interfaces.Service;
using TemplateDDD.Domain.Models;
using TemplateDDD.Service.Validators;
using TemplateDDD.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TemplateDDD.Domain.Interfaces.Infra;
using TemplateDDD.Domain.ViewModel;
using TemplateDDD.Infra;

namespace TemplateDDD.Service.Services
{
    public class SampleService : BaseService, ISampleService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;
        private readonly ITesteRepository _testeRepository;
        private readonly ConnectionManager _connectionManager;

        public SampleService(IMapper mapper, ISampleRepository sampleRepository, ITesteRepository testeRepository, ConnectionManager connectionManager)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
            _testeRepository = testeRepository;
            _connectionManager = connectionManager;
        }

        public SampleViewModel Get(int id)
        {
            return _mapper.Map<SampleViewModel>(_sampleRepository.GetById(id));
        }
        
        public int Post(InsertSampleCommand sample)
        {
            Validate(sample, new InsertSampleValidator()); //Validations are realized on FluentValidation 
            _testeRepository.Insert(new Teste() { Id = new Random().Next(), Desc = "Teste" });
            var result = _sampleRepository.Insert(_mapper.Map<Sample>(sample));
            return result;
        }

        public bool Put(UpdateSampleCommand sample)
        {
            Validate(sample, new UpdateSampleValidator());
            return _sampleRepository.Update(_mapper.Map<Sample>(sample));
        }

        public bool Delete(int id)
        {
            return _sampleRepository.Delete(id);
        }
    }
}
