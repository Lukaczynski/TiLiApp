using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiLi.Core.Interfaces.Gateways.Repositories;

namespace TiLi.Api
{
    public class AuthorizePermissions : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; }
     
        


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(Permissions))
            {
                context.Result = new UnauthorizedResult();
                return;
            }


            //The below line can be used if you are reading permissions from token
            //var permissionsFromToken=context.HttpContext.User.Claims.Where(x=>x.Type=="Permissions").Select(x=>x.Value).ToList()

            //Identity.Name will have windows logged in user id, in case of Windows Authentication
            //Indentity.Name will have user name passed from token, in case of JWT Authenntication and having claim type "ClaimTypes.Name"


            var requiredPermissions = Permissions.Split(","); 
            foreach (var x in requiredPermissions)
            {
                if (requiredPermissions.Contains(x))
                    return; 
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
