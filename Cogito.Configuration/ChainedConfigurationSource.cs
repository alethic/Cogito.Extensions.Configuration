using System;

using Microsoft.Extensions.Configuration;

namespace Cogito.Configuration
{

    /// <summary>
    /// Represents a chained IConfiguration as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class ChainedConfigurationSource :
        IConfigurationSource
    {

        readonly IConfiguration config;
        readonly Func<string, string, bool> filter;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="config"></param>
        public ChainedConfigurationSource(IConfiguration config, Func<string, string, bool> filter = null)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.filter = filter ?? ((k, v) => true);
        }

        /// <summary>
        /// The chained configuration.
        /// </summary>
        public IConfiguration Configuration => config;

        /// <summary>
        /// Gets the filter to apply over the source configuration.
        /// </summary>
        public Func<string, string, bool> Filter => filter;

        /// <summary>
        /// Builds the <see cref="ChainedConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="ChainedConfigurationProvider"/></returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new ChainedConfigurationProvider(this);

    }

}