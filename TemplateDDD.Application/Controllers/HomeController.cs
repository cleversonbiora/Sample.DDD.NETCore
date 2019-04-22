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
    public class HomeController : Controller
    {
        [Route(""), HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public RedirectResult RedirectToSwaggerUi()
        {
            return Redirect("/swagger/");
        }
    }
}
