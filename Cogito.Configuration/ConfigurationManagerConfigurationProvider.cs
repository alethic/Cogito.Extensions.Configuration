#if NET451 || NET462 || NET47

using System;
using System.Collections.Generic;
using System.Configuration;

using Microsoft.Extensions.Configuration;

namespace Cogito.Configuration
{

    /// <summary>
    /// Provides known configuration values from the System.Configuration infrastructure.
    /// </summary>
    class ConfigurationManagerConfigurationProvider :
        ConfigurationProvider,
        IConfigurationSource
    {

        readonly IDictionary<string, string> appSettings;
        readonly IDictionary<string, string> connectionStrings;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="appSettings"></param>
        /// <param name="connectionStrings"></param>
        public ConfigurationManagerConfigurationProvider(
            IDictionary<string, string> appSettings,
            IDictionary<string, string> connectionStrings)
        {
            this.appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        /// <summary>
        /// Loads the configuration data.
        /// </summary>
        public override void Load()
        {
            if (appSettings != null)
                foreach (var kvp in appSettings)
                    AddAppSetting(kvp.Key, kvp.Value);

            if (connectionStrings != null)
                foreach (var kvp in connectionStrings)
                    AddConnectionString(kvp.Key, kvp.Value);
        }

        void AddAppSetting(string path, string keyName)
        {
            var v = ConfigurationManager.AppSettings[keyName];
            if (!string.IsNullOrWhiteSpace(v))
                Data.Add(path, v);
        }

        void AddConnectionString(string path, string keyName)
        {
            var v = ConfigurationManager.ConnectionStrings[keyName]?.ConnectionString;
            if (!string.IsNullOrWhiteSpace(v))
                Data.Add(path, v);
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return this;
        }

    }

}

#endif
