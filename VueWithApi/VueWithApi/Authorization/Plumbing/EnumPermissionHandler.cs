using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EnumPermissionHandler : AuthorizationHandler<EnumPermissionRequirement<Permission>>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
        EnumPermissionRequirement<Permission> requirement)
    {
        if(PermissionLogic.UserHasPermission(context.User, requirement.Permission, context.Resource))
        {            
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
