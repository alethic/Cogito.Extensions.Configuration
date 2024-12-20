using Autofac;

using Cogito.Autofac;

namespace Cogito.Extensions.Configuration.Autofac.Sample1
{

    public class AssemblyModule : ModuleBase
    {

        protected override void Register(ContainerBuilder builder)
        {
            builder.RegisterFromAttributes(typeof(AssemblyModule).Assembly);
        }

    }

}
