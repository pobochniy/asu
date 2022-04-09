using Atheneum.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Middleware
{
    public class AuthorizeRoles : Attribute, IFilterFactory
    {
        public bool IsReusable => false;
        private RoleEnum[] Roles { get; }

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