using System;
using System.Security.Claims;

namespace Atheneum.Extentions.Auth
{
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Получение идентификатора аутентифицированного пользователя
        /// </summary>
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal));

            var id = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);
            return id;
        }
    }
}
