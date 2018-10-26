using Microsoft.AspNetCore.Authorization;
using System;

public static class AuthorizationOptionsExtensions
{
    public static AuthorizationOptions AddCustomAuthorizationPolicies<TPermission>(this AuthorizationOptions options)
        where TPermission : struct
    {
        foreach (TPermission permission in Enum.GetValues(typeof(TPermission)))
        {
            options.AddPolicy(permission.ToString(), policy => policy.Requirements.Add(new EnumPermissionRequirement<TPermission>(permission)));
        }
        return options;
    }
}
