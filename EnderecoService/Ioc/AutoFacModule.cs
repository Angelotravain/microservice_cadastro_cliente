using Autofac;
using EnderecoService.Models;
using EnderecoService.Repositories.Generic;
using EnderecoService.Services;

namespace EnderecoService.Ioc
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EnderecoService.Services.EnderecoService>().As<IEnderecoService>();
            builder.RegisterType<Generic<EnderecoModel>>().As<IGeneric<EnderecoModel>>();
        }
    }
}
