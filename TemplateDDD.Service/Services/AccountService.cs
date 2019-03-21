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
using TemplateDDD.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
//https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-2.2
namespace TemplateDDD.Service.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly RoleManager<ApiRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountService(IMapper mapper, ISampleRepository sampleRepository, UserManager<ApiUser> userManager, RoleManager<ApiRole> roleManager, SignInManager<ApiUser> signInManager, IEmailSender emailSender)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
        public async Task AddRole()
        {
        }

        public async Task<object> Register(RegisterAccountCommand login, ClaimsPrincipal User)
        {
            var user = new ApiUser { UserName = login.Email, Email = login.Email, FirstName = login.FirstName, LastName = login.LastName };
            var result = await _userManager.CreateAsync(user, login.Password);
            if (!result.Succeeded)
                throw new ArgumentException("Falha ao registrar usuário");
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await _signInManager.SignInAsync(user, isPersistent: false);
            var token = GenerateJwtToken(user);
            return new { token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        public async Task<object> Login(LoginAccountCommand login, ClaimsPrincipal User)
        {
            Validate(login, new LoginAccountValidator());
            var result = await _signInManager.PasswordSignInAsync(login.User, login.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.GetUserAsync(User);
                var token = GenerateJwtToken(user);
                return new { token = new JwtSecurityTokenHandler().WriteToken(token) };
            }
            if (result.IsLockedOut)
            {
                throw new ArgumentException("User account locked out.");
            }
            else
            {
                throw new ArgumentException("Invalid login attempt.");
            }
        }

        private static JwtSecurityToken GenerateJwtToken(ApiUser user)
        {
            var claims = new[]{
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(new Sha512(Environment.GetEnvironmentVariable("Password")).ToString()));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("Issuer"),
                audience: Environment.GetEnvironmentVariable("Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            return token;
        }
    }
}
