using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Identity.Extensions
{
    /// <summary>
    /// Permission-based authorization attribute.
    /// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeRolePermissionAttribute : AuthorizeAttribute
    {
        //private UserService _userService = new UserService();
        private string[] Permissions { get; set; }
        public AuthorizeRolePermissionAttribute(params object[] permissions)
        {
            Permissions = permissions.Select(p => p.ToString()).ToArray();
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext) && Task.Run(() => httpContext.AuthorizePermission(Permissions.ToList())).Result;
        }
    }
}