using System.Collections.Generic;

namespace Identity.Extensions
{
    public interface IPermission<out TKey, TRolePermission>
        where TRolePermission : IRolePermission<TKey>
    {
        TKey Id { get; }
        string Name { get; set; }
        long Origin { get; set; }
        bool IsGlobal { get; set; }
        ICollection<TRolePermission> Roles { get; set; }
    }
}