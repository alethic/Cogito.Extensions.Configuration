using System;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration
{

    /// <summary>
    /// <see cref="IConfigurationBuilder"/> extension methods for the chaind configuration provider.
    /// </summary>
    public static class ChainedBuilderExtensions
    {

        /// <summary>
        /// Adds an existing configuration to <paramref name="configurationBuilder"/>.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="config">The <see cref="IConfiguration"/> to add.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder, IConfiguration config, Func<string, string, bool> filter = null)
        {
            if (configurationBuilder == null)
                throw new ArgumentNullException(nameof(configurationBuilder));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            return configurationBuilder.Add(new ChainedConfigurationSource(config, filter));
        }

    }

}