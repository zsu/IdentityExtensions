﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Identity.Extensions
{
    public interface IPermissionManager : IDisposable
    {
        Task<bool> CheckPermissionAsync(string name, IList<string> roles, string description = null,
            bool isGlobal = false, HttpContextBase httpContext = null);

        Task<bool> AuthorizePermissionAsync(string name, string description = null,
            bool isGlobal = false);

        Task<bool> AuthorizePermissionAsync(HttpContextBase httpContext, string name,
            string description = null, bool isGlobal = false);
        Task<bool> AuthorizePermissionAsync(List<string> permissions);
        Task<bool> AuthorizePermissionAsync(string userName, List<string> roles);
        Task InitialConfiguration();
    }
}