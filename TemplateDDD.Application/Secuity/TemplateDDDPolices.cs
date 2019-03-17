using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateDDD.Application.Secuity
{
    public static class TemplateDDDPolices
    {
        public static void UseAuthorizationOptions(this AuthorizationOptions options)
        {
            options.AddPolicy("UpdateParametros", policy =>
                policy.RequireAssertion(context =>
                context.User.Identity.Name == "TemplateDDD"));
        }
    }
}
