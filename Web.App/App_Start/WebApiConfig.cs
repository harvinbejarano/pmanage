﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.App.App_Start;
using Web.App.Security;

namespace Web.App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            config.Filters.Add(new GeneralExceptionFilterAttribute());

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}