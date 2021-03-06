﻿using ECommerce.Migrations;
using ECommerce.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System;
using ECommerce.Classes;

namespace ECommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ECommerceContext,Configuration>());//this line is for can active the Aotomatic  migration 

            CheckRolesAndSuperUser();// este metodo para repuperacion de contrasena  enviando email

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckRolesAndSuperUser()
        {
            UsersHelper.CheckRole("Admin");
            UsersHelper.CheckRole("User");
            UsersHelper.CheckRole("Customer");
            UsersHelper.CheckSuperUser();
        }
    }
}
