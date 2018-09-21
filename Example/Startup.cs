using Identity.Extensions;
using IdentitySample.Models;
using Owin;

namespace IdentitySample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UsePermissionManager(ApplicationPermissionManager.Create());
        }
    }
}
