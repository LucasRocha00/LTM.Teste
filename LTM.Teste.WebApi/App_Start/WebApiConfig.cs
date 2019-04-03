using LTM.Teste.Business;
using LTM.Teste.Contracts.Business;
using LTM.Teste.Contracts.Repository;
using LTM.Teste.Repository.Features;
using LTM.Teste.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace LTM.Teste.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var container = new UnityContainer();
            container.RegisterType<IDocumentoBusiness, DocumentoBusiness>(new HierarchicalLifetimeManager());
            container.RegisterType<IDocumentoRepository, DocumentoRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityConfig(container);


            ConfigureUnit();
        }

        private static void ConfigureUnit()
        {

        }
    }
}
