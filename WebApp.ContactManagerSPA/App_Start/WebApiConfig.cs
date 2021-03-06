﻿using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApp.ContactManagerSPA.DAL;
using WebApp.ContactManagerSPA.DI;
using WebApp.ContactManagerSPA.Infrastructure;
using WebApp.ContactManagerSPA.Repository;
using WebApp.ContactManagerSPA.Services;

namespace WebApp.ContactManagerSPA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //var config = new HttpSelfHostConfiguration("http://localhost:8080");
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IContactsRepository, ContactsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContactsService, ContactsService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountsRepository, AccountsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountsService, AccountsService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogAdapter, Log4NetAdapter>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container); 
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
