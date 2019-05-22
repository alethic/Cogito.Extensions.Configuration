using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Describes a class that will produce the configuration root.
    /// </summary>
    public interface IConfigurationRootBuilder
    {

        /// <summary>
        /// Builds the configuration root.
        /// </summary>
        /// <returns></returns>
        IConfigurationRoot BuildConfiguration();

    }

}