using Microsoft.AspNet.Identity.EntityFramework;

namespace Identity.Extensions
{
    public class IdentityUserStore<TUser> : UserStore<TUser, ExtendedRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> where TUser: IdentityUser
    {
        public IdentityUserStore(ExtendedDbContext<TUser> context) : base(context)
        {
        }
    }
    public class IdentityUserStore<TUser,TRole> : UserStore<TUser, TRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> 
        where TUser : IdentityUser
        where TRole: ExtendedRole
    {
        public IdentityUserStore(ExtendedDbContext<TUser,TRole> context) : base(context)
        {
        }
    }
}