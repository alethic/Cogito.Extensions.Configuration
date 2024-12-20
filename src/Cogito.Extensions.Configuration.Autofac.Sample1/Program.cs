using System.Threading.Tasks;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Cogito.Autofac;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cogito.Extensions.Configuration.Autofac.Sample1
{

    public static class Program
    {

        public static async Task Main(string[] args)
        {
            var b = new ContainerBuilder();
            b.RegisterAllAssemblyModules();
            using var c = b.Build();

            await Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(c))
                .ConfigureWebHostDefaults(w => w.UseStartup<Startup>())
                .RunConsoleAsync();
        }

    }

}
