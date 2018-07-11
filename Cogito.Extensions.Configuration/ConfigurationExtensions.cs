using System;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration
{

    /// <summary>
    /// Extensions for the Microsoft Extensions Configuration framework.
    /// </summary>
    public static class ConfigurationExtensions
    {

        /// <summary>
        /// Binds a configuration section to a new instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Bind<T>(this IConfigurationRoot config, string path)
            where T : class, new()
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var c = new T();
            config.GetSection(path)?.Bind(c);
            return c;
        }

        /// <summary>
        /// Binds a configuration section to a new instance of the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static object Bind(this IConfigurationRoot config, Type type, string path)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            var c = Activator.CreateInstance(type);
            config.GetSection(path)?.Bind(c);
            return c;
        }

    }

}
