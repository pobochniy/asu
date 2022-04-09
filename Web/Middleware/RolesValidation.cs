namespace Web.Middleware
{
    public class RolesValidation : Attribute, IActionFilter
    {
        public RoleEnum[] roles { get; set; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401);
                return;
            }

            var userRoles = context.HttpContext.User.Claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => (RoleEnum)int.Parse(x.Value))
                .ToArray();

            var isAllowed = false;
            foreach (var el in roles)
            {
                if (userRoles.Contains(el))
                {
                    isAllowed = true;
                    break;
                }
            }
            if (!isAllowed) context.Result = new StatusCodeResult(403);
        }
    }
}
