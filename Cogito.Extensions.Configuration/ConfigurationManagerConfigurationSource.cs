#if NET451 || NET462 || NET47

using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration
{

    /// <summary>
    /// Maps ConfigurationManager settings to Extension settings.
    /// </summary>
    class ConfigurationManagerConfigurationSource :
        IConfigurationSource
    {

        readonly Dictionary<string, string> appSettings;
        readonly Dictionary<string, string> connectionStrings;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public ConfigurationManagerConfigurationSource()
        {
            this.appSettings = new Dictionary<string, string>();
            this.connectionStrings = new Dictionary<string, string>();
        }

        /// <summary>
        /// Maps an appsetting key to a given path in the configuration.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        public void AddAppSetting(string path, string key)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            appSettings[path] = key;
        }

        /// <summary>
        /// Maps a connectionstring name to a given path in the configuration.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public void AddConnectionString(string path, string name)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            connectionStrings[path] = name;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            return new ConfigurationManagerConfigurationProvider(appSettings, connectionStrings);
        }

    }

}

#endif