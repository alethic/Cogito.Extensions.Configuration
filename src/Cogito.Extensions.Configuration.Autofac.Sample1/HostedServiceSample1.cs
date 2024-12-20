using System;
using System.Threading;
using System.Threading.Tasks;

using Cogito.Autofac;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cogito.Extensions.Configuration.Autofac.Sample1
{

    [RegisterAs(typeof(IHostedService))]
    class HostedServiceSample1 : IHostedService
    {

        readonly ILogger<HostedServiceSample1> logger;
        readonly IConfigurationRoot cr;
        readonly IConfiguration c;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="cr"></param>
        /// <param name="c"></param>
        public HostedServiceSample1(ILogger<HostedServiceSample1> logger, IConfigurationRoot cr, IConfiguration c)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.cr = cr ?? throw new ArgumentNullException(nameof(cr));
            this.c = c ?? throw new ArgumentNullException(nameof(c));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Starting");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Stopping");
            return Task.CompletedTask;
        }

    }

}
