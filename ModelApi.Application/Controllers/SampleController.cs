using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ModelApi.Domain.Interfaces.Service;
using ModelApi.Domain.Models;
using FluentValidation;
using ModelApi.Domain.Commands.Sample;

//https://medium.com/@alexalves_85598/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686

namespace ModelApi.Application.Controllers
{
    [EnableCors("Cors")]
    [Route("api/Sample")]
    public class SampleController : BaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleAppService)
        {
            _sampleService = sampleAppService;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(_sampleService.Get());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InsertSampleCommand sample)
        {
           return Response(_sampleService.Post(sample));
        }
        
    }
}
