using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TemplateDDD.Domain.Interfaces.Service;
using TemplateDDD.Domain.Models;
using FluentValidation;
using TemplateDDD.Domain.Commands.Sample;
using TemplateDDD.CrossCutting.Attributes;

namespace TemplateDDD.Application.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[Controller]")]
    public class SampleController : BaseController
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleAppService) => _sampleService = sampleAppService;

        [AllowAnonymous, HttpGet]
        public IActionResult ListAll() => Response(null);

        //[TestAutmated(1)]
        [AllowAnonymous, HttpGet("{id}")]
        public IActionResult Get(int id) => Response(_sampleService.Get(id));

        [AllowAnonymous, HttpGet("filter")]
        public IActionResult ListFilter(string description, string name) => Response(null);

        [AllowAnonymous, HttpPost]
        public IActionResult Post([FromBody]InsertSampleCommand sample) => Response(_sampleService.Post(sample));

        [AllowAnonymous, HttpPut]
        public IActionResult Put([FromBody]UpdateSampleCommand sample) => Response(_sampleService.Put(sample));
        [AllowAnonymous, HttpDelete]
        public IActionResult Delete([FromBody]int id) => Response(_sampleService.Delete(id));
    }
}
