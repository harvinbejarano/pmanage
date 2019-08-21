using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Web.App
{
    public static class UnityConfig
    {
        public static UnityContainer Container;

        static UnityConfig()
        {
            Container = new UnityContainer();
        }

        public static void RegisterComponents()
        {
            Services.Config.UnityConfig.RegisterComponents(Container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }
    }
}