using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Identity.Extensions
{
    public interface IPermissionStore<in TKey, TPermission>
    {
        Task<TPermission> FindPermissionAsync(string name, long origin, bool isGlobal = false);
        Task<TPermission> CreatePermissionAsync(string name, long origin, string description = null,
            bool isGlobal = false, HttpContextBase httpContext = null);
        Task DeletePermissionAsync(TKey id);
        Task<IList<string>> GetRolesAsync(int userId, ClaimsPrincipal user = null);
        Task<IList<string>> GetRolesAsync(TPermission permission);
        Task InitialConfiguration();
        Task<bool> AuthorizePermissionAsync(List<string> roles);
        Task<bool> AuthorizePermissionAsync(string userName, List<string> roles);
    }
}