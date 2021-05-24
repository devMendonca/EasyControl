﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(EasyControl.Startup))]

namespace EasyControl
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new
            CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes
  .ApplicationCookie,
                LoginPath = new PathString("/Usuarios/Login"),
                LogoutPath = new PathString("/Usuarios/Logout")
            });
        }
    }
}
