#if NET451 || NET462 || NET47

using System;
using System.Linq;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration
{

    /// <summary>
    /// Provides extension methds for the <see cref="IConfigurationBuilder"/>.
    /// </summary>
    public static class ConfigurationManagerConfigurationExtensions
    {

        /// <summary>
        /// Gets the <see cref="ConfigurationManagerConfigurationSource"/> registered with the builder.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        static ConfigurationManagerConfigurationSource GetSource(IConfigurationBuilder builder)
        {
            if (builder == null)
                throw new NullReferenceException(nameof(builder));

            var source = builder.Sources
                .OfType<ConfigurationManagerConfigurationSource>()
                .FirstOrDefault();
            if (source == null)
                builder.Add(source = new ConfigurationManagerConfigurationSource());

            return source;
        }

        /// <summary>
        /// Imports an AppSetting from the ConfigurationManager.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddConfigurationManagerAppSetting(this IConfigurationBuilder builder, string path, string key)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            var source = GetSource(builder);
            source.AddAppSetting(path, key);
            return builder;
        }

        /// <summary>
        /// Imports an AppSetting from the ConfigurationManager.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IConfigurationBuilder AddConfigurationManagerConnectionString(this IConfigurationBuilder builder, string path, string name)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            var source = GetSource(builder);
            source.AddConnectionString(path, name);
            return builder;
        }

    }

}

#endif
