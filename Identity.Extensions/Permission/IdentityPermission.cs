using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Identity.Extensions
{

    public class IdentityPermission : IdentityPermission<string, IdentityRolePermission>
    {
        public IdentityPermission()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
    public class IdentityPermission<TKey, TRolePermission>
        : IPermission<TKey, TRolePermission>
        where TRolePermission : IdentityRolePermission<TKey>
    {
        public virtual TKey Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual long Origin { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string AreaName { get; set; }

        /// <summary>
        /// Check whether the permission is accessible at the global level or local (using origin value)
        /// </summary>
        public virtual bool IsGlobal { get; set; }

        public virtual ICollection<TRolePermission> Roles { get; set; }
    }
}