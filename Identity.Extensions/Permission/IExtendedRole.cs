using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Identity.Extensions
{
    public interface IExtendedRole<out TKey, TRolePermission> : IRole<TKey>
    where TRolePermission : IdentityRolePermission<TKey>
    {
        ICollection<TRolePermission> Permissions { get; set; }
    }
}