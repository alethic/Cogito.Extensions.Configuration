using System;
using System.Collections.Generic;
using System.Linq;

using Cogito.Autofac;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Builds the default configuration.
    /// </summary>
    [RegisterAs(typeof(IConfigurationRootBuilder))]
    public class DefaultConfigurationRootBuilder :
        IConfigurationRootBuilder
    {

        readonly IEnumerable<IConfigurationBuilderConfigurationProvider> providers;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        public DefaultConfigurationRootBuilder(IOrderedEnumerable<IConfigurationBuilderConfigurationProvider> providers)
        {
            this.providers = providers ?? throw new ArgumentNullException(nameof(providers));
        }

        /// <summary>
        /// Builds the configuration.
        /// </summary>
        /// <returns></returns>
        public IConfigurationRoot BuildConfiguration()
        {
            var builder = BuildDefaultConfigurationBuilder();
            builder = ApplyDefaults(builder, Environment.GetCommandLineArgs());
            builder = ApplyConfigurations(builder);
            return builder.Build();
        }

        /// <summary>
        /// Builds the default <see cref="ConfigurationBuilder"/> instance.
        /// </summary>
        /// <returns></returns>
        IConfigurationBuilder BuildDefaultConfigurationBuilder()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
        }

        /// <summary>
        /// Builds a default configuration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        protected IConfigurationBuilder ApplyDefaults(IConfigurationBuilder builder, string[] args)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return builder;
        }

        /// <summary>
        /// Applies extra configuration from the builder configuration configurations.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        IConfigurationBuilder ApplyConfigurations(IConfigurationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            foreach (var provider in providers)
                foreach (var configuration in provider.GetConfigurations())
                    builder = configuration.Apply(builder);

            return builder;
        }

    }

}
