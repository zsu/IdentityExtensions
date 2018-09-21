using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Extensions
{
    public class IdentityRoleStore<TUser> : RoleStore<ExtendedRole, string, IdentityUserRole> where TUser : IdentityUser
    {
        public IdentityRoleStore(ExtendedDbContext<TUser> context) : base(context)
        {
        }
    }
    public class IdentityRoleStore<TUser,TRole> : RoleStore<TRole, string, IdentityUserRole> 
        where TUser : IdentityUser
        where TRole: ExtendedRole,new()
    {
        public IdentityRoleStore(ExtendedDbContext<TUser,TRole> context) : base(context)
        {
        }
    }
}