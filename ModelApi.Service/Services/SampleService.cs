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
using ModelApi.Domain.ViewModel;

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
        public SampleViewModel Get(int id)
        {
            return _mapper.Map<SampleViewModel>(_sampleRepository.GetById(id));
        }
        
        public int Post(InsertSampleCommand sample)
        {
            Validate(sample, new InsertSampleValidator());
            return _sampleRepository.Insert(_mapper.Map<Sample>(sample));
        }
        
    }
}
