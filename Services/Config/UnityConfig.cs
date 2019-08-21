using Services.Core;
using Services.Impl;
using Unity;

namespace Services.Config
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            Repositories.DI.UnityConfig.RegisterComponents(container);
            container.RegisterType<IClientService, ClientService>();
        }
    }
}
