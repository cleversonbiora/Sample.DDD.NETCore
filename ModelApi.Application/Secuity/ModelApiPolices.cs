using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelApi.Application.Secuity
{
    public static class ModelApiPolices
    {
        public static void UseAuthorizationOptions(this AuthorizationOptions options)
        {
            options.AddPolicy("UpdateParametros", policy =>
                policy.RequireAssertion(context =>
                context.User.Identity.Name == "ModelApi"));
        }
    }
}
