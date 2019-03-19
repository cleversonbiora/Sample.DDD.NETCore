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
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TemplateDDD.CrossCutting.Utils;

namespace TemplateDDD.Service.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;

        public AccountService(IMapper mapper, ISampleRepository sampleRepository)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
        }
        
        
        public object Login(LoginAccountCommand login)
        {
            Validate(login, new LoginAccountValidator());

            if (login.Password != "123")
                throw new ArgumentException("User or Password inccorect!");

            var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.User)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new Sha512(Environment.GetEnvironmentVariable("Password")).ToString()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("Issuer"),
                audience: Environment.GetEnvironmentVariable("Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new { token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
