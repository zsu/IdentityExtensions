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
  
  Create ApplicationDbContext : ExtendedDbContext<ApplicationUser,ApplicationRole> using IdentityUser/ExtendedRole model or extended User/Role model inherited from them;
  * Change IdentityConfig.cs
  
  Create ApplicationUserManager/ApplicationSignInManager/ApplicationPermissionManager/ApplicationRoleManager using IdentityUser/ExtendedRole model or extended User/Role model inherited from them;
  * Call app.UsePermissionManager(ApplicationPermissionManager.Create()); in Startup.cs
  * Change Startup.Auth.cs
```xml
app.CreatePerOwinContext(ApplicationDbContext.Create);
app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
```
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
