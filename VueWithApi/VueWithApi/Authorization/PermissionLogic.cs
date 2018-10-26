using VueWithApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

public static class PermissionLogic
{
    public static bool UserHasPermission(ClaimsPrincipal user, Permission permission, object resource)
    {
        // Centralized permission logic

        var isUser = user.Identity.IsAuthenticated && user.IsInRole(SiteRoles.User);
        var isAdmin = user.Identity.IsAuthenticated && user.IsInRole(SiteRoles.User);

        switch (permission)
        {
            case Permission.ViewAnyProducts:
                if (user.Identity.IsAuthenticated)
                {
                    return true;
                }
                break;
            case Permission.CreateProduct:
            case Permission.ViewMyProducts:
            case Permission.UpdateMyProducts:
                if (isUser)
                {
                    return true;
                }
                break;
            case Permission.DeleteMyProducts:
                if (isUser && user.HasClaim("hair_color", "brown"))
                {
                    return true;
                }
                break;
            case Permission.UpdateAnyProducts:
            case Permission.DeleteAnyProducts:
                if (isAdmin)
                {
                    return true;
                }
                break;
            case Permission.UpdateSpecificProduct:
                // if check is coming from an attribute route, resource is the mvc context
                var mvcContext = resource as AuthorizationFilterContext;
                if(mvcContext?.HttpContext.Request.Query["id"].Equals("5") == true)
                {

                }
                // a call to User.Can(...) might pass in a specific type of resource to check
                var product = resource as Product;
                if(product?.Owner == "bob")
                {
                    return true;
                }
                break;
        }
        return false;
    }
}
