using Repositories.Core;
using Repositories.Impl;
using Unity;

namespace Repositories.DI
{
    public static class UnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IClientRepository, ClientRepository>();
        }
    }
}
