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
        readonly IEnumerable<IConfiguration> existing;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="providers"></param>
        /// <param name="existing"></param>
        public DefaultConfigurationRootBuilder(IOrderedEnumerable<IConfigurationBuilderConfigurationProvider> providers, IEnumerable<IConfiguration> existing = null)
        {
            this.providers = providers ?? throw new ArgumentNullException(nameof(providers));
            this.existing = existing;
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
        public IConfigurationBuilder BuildDefaultConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory);

            if (existing != null)
                foreach (var i in existing)
                    return builder = builder.AddConfiguration(i);

            return builder;
        }

        /// <summary>
        /// Builds a default configuration.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public IConfigurationBuilder ApplyDefaults(IConfigurationBuilder builder, string[] args)
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
        public IConfigurationBuilder ApplyConfigurations(IConfigurationBuilder builder)
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
