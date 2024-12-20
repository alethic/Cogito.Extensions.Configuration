using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Describes a class that can add configuration to the configuration builder.
    /// </summary>
    public interface IConfigurationBuilderConfiguration
    {

        /// <summary>
        /// Applies the configuration to the configuration builder.
        /// </summary>
        /// <param name="builder"></param>
        IConfigurationBuilder Apply(IConfigurationBuilder builder);

    }

}
