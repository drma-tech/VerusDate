using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace VerusDate.Server.Core.Helper
{
    public static class ControllerHelper
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            if (!httpContext.User.Identity.IsAuthenticated) throw new InvalidOperationException("Usuário não autenticado");

            return httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}