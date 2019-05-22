using System;
using System.Collections.Generic;
using System.Linq;

using Autofac;

using Cogito.Autofac;

namespace Cogito.Extensions.Configuration.Autofac
{

    /// <summary>
    /// Provides support for attribute based registration of configuration objects.
    /// </summary>
    class RegisterConfigurationHandler :
        RegisterTypeHandler
    {

        protected override void Register(
            ContainerBuilder builder,
            Type type,
            IEnumerable<IRegistrationRootAttribute> attributes,
            IEnumerable<IRegistrationBuilderAttribute> builders)
        {
            foreach (var attribute in attributes.OfType<RegisterConfigurationAttribute>())
                ApplyBuilders(type, builder.RegisterConfigurationBinding(type, attribute.Path), attribute, builders);
        }

    }

}
