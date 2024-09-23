using Autofac;
using ClienteService.Models;
using ClienteService.Repositories.Generic;
using ClienteService.Services;

namespace ClienteService.Ioc
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteService.Services.ClienteService>().As<IClienteService>();
            builder.RegisterType<Generic<ClienteModel>>().As<IGeneric<ClienteModel>>();
        }
    }
}
