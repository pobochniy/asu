using Atheneum.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Web.Middleware
{
    public class AuthorizeRoles : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        public RoleEnum[] Roles { get; set; }

        public AuthorizeRoles(params RoleEnum[] roles)
        {
            Roles = roles;
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetService(typeof(RolesValidation)) as RolesValidation;

            filter.roles = Roles;

            return filter;
        }
    }
}
