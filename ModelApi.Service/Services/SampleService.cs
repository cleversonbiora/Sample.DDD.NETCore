using FluentValidation;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Domain.Models;
using ModelApi.Service.Validators;
using ModelApi.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ModelApi.Domain.Interfaces.Infra;

namespace ModelApi.Service.Services
{
    public class SampleService : BaseService, ISampleService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;

        public SampleService(IMapper mapper, ISampleRepository sampleRepository)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
        }
        public Sample Get()
        {
            return _sampleRepository.GetById(5);
        }
        
        public int Post(InsertSampleCommand sample)
        {
            Validate(sample, new InsertSampleValidator());
            var model = _mapper.Map<Sample>(sample);
            return _sampleRepository.Insert(model);
        }
        
    }
}
