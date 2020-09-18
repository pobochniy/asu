using Atheneum.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Web.Middleware
{
    public class AuthorizeRoles : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        public RoleEnum[] roles { get; set; }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            var filter = serviceProvider.GetService(typeof(RolesValidation)) as RolesValidation;

            filter.roles = roles;

            return filter;
        }
    }
}
