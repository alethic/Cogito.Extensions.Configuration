using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cogito.Extensions.Configuration.Autofac.Sample1
{

    public class Startup
    {

        public void Configure(IApplicationBuilder app)
        {
            app.Use((ctx, next) =>
            {
                var l = ctx.RequestServices.GetRequiredService<IConfiguration>();
                return next();
            });
        }

    }

}