using System;
using System.Collections.Generic;
using System.Linq;

using Cogito.Autofac;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Provides the default <see cref="IConfigurationBuilderConfiguration"/> instances in the container registry.
    /// </summary>
    [RegisterAs(typeof(IConfigurationBuilderConfigurationProvider))]
    [RegisterOrder(0)]
    public class DefaultConfigurationBuilderConfigurationProvider :
        IConfigurationBuilderConfigurationProvider
    {

        readonly IEnumerable<IConfigurationBuilderConfiguration> configurations;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="configurations"></param>
        public DefaultConfigurationBuilderConfigurationProvider(IOrderedEnumerable<IConfigurationBuilderConfiguration> configurations)
        {
            this.configurations = configurations ?? throw new ArgumentNullException(nameof(configurations));
        }

        public IEnumerable<IConfigurationBuilderConfiguration> GetConfigurations()
        {
            return configurations;
        }

    }

}
