using Microsoft.AspNetCore.Authorization;

public class EnumPermissionRequirement<TPermission> : IAuthorizationRequirement
    where TPermission : struct
{
    public TPermission Permission { get; private set; }

    public EnumPermissionRequirement(TPermission permission)
    {
        Permission = permission;
    }
}
