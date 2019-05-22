using System.Collections.Generic;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Describes a class that will provide configurations.
    /// </summary>
    public interface IConfigurationBuilderConfigurationProvider
    {

        /// <summary>
        /// Gets the available configuration configurations.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IConfigurationBuilderConfiguration> GetConfigurations();

    }

}
