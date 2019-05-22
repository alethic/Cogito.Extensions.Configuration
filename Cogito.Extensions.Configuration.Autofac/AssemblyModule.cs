using Autofac;

using Cogito.Autofac;

namespace Cogito.Extensions.Configuration.Autofac
{

    public class AssemblyModule :
        ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
            builder.Register(ctx => ctx.Resolve<IConfigurationRootBuilder>().BuildConfiguration()).SingleInstance();
        }

    }

}
