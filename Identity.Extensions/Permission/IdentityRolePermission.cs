using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Identity.Extensions
{
    public class IdentityRolePermission : IdentityRolePermission<string>
    {

    }
    public class IdentityRolePermission<TKey> : IRolePermission<TKey>
    {
        public virtual TKey RoleId { get; set; }
        public virtual TKey PermissionId { get; set; }
    }

}