using System;
using System.Linq;
using System.Security.Claims;

public static class ClaimsPrincipalExtensions
{
    public static bool Can(this ClaimsPrincipal user, Permission permission, object resource = null)
    {
        return PermissionLogic.UserHasPermission(user, permission, resource);
    }
}
