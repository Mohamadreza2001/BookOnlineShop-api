﻿using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Common.AspNetCore
{
    public static class ClaimUtility
    {
        public static long GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            return Convert.ToInt64(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}
