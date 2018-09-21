using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Identity.Extensions
{
    public class ExtendedRole : ExtendedRole<string, IdentityUserRole, IdentityRolePermission>
    {
        public ExtendedRole()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public class ExtendedRole<TKey, TUserRole, TRolePermission>
            : Microsoft.AspNet.Identity.EntityFramework.IdentityRole<TKey, TUserRole>,
                IExtendedRole<TKey, TRolePermission>
            where TRolePermission : IdentityRolePermission<TKey>
            where TUserRole : IdentityUserRole<TKey>
    {
        public string Description { get; set; }

        public virtual ICollection<TRolePermission> Permissions { get; set; }

    }
}