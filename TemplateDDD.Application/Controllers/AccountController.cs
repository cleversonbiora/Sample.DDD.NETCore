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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TemplateDDD.Application.Controllers
{
    [Route("api/[Controller]")]
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult RequestToken()
        {

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, "Amendoim")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaa"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Response(new{ token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Response(new { token = "Ok" });
        }
    }
}
