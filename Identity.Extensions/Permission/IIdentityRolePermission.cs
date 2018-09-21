using System.Collections.Generic;

namespace Identity.Extensions
{
    public interface IRolePermission<TKey>
    {
        TKey RoleId { get; set; }
        TKey PermissionId { get; set; }
    }
}