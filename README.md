# What is IdentityExtensions

Asp.Net Identity permission extesions. Added permissions to roles implementation.

Some of the features of SessionMessage are:

  * Two levels Role/Permissions authorizatioin.

# NuGet
```xml
Install-Package Identity.Extensions
```
# Getting started with Identity.Extensions

  * Change IdentityModel.cs
  Extend User model by inherited from IdentityUser(Optional); 
  Extend Role model by inherited from ExtendedRole(Optional);
  CreExteate ApplicationDbContext : ExtendedDbContext<ApplicationUser,ApplicationRole> if User/Role model is extended;
  * Change IdentityConfig.cs
  Extend ApplicationSignInManager/ApplicationPermissionManager/ApplicationRoleManager if User/Role model is extended;
  * Call app.UsePermissionManager(ApplicationPermissionManager.Create()); in Startup.cs
  * Apply attribute to Class/Method to authorize access
```xml
[AuthorizeRolePermission("Admin,SecurityAdmin")]
```
Or call the async function to check authorization:
```xml
HttpContext.Current.GetPermissionManager().AuthorizePermissionAsync(new List<string> { "Admin" }).Result
```
# License
All source code is licensed under MIT license - http://www.opensource.org/licenses/mit-license.php
