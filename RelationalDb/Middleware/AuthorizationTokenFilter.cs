using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RelationalDb.Middleware
{
    public class AuthorizationTokenFilter : Attribute, IAuthorizationFilter
    {
        // Correct authorization token
        public string Token { get => "Basic 1234567890abcDEF"; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //bool tryGetValue = context.HttpContext.Request.Headers.TryGetValue("Authorization", out authorizationToken);

            string authorizationToken = context.HttpContext.Request.Headers["Authorization"];


            if (!string.IsNullOrEmpty(authorizationToken))
            {
                if (authorizationToken == Token)
                {
                    Debug.WriteLine("+++++ Good Authorization Token");
                }
                else
                {
                    Debug.WriteLine("+++++ Bad Authorization Token");

                    context.Result = new UnauthorizedResult();
                }
            }
            else
            {
                Debug.WriteLine("+++++ No Authorization Token");

                context.Result = new UnauthorizedResult();
            }
        }
    }
}
