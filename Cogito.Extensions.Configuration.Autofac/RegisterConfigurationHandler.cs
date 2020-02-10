using System;
using System.Collections.Generic;

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

        protected override void RegisterCore(
            ContainerBuilder builder,
            Type type,
            IRegistrationRootAttribute attribute,
            IEnumerable<IRegistrationBuilderAttribute> builders)
        {
            if (attribute is RegisterConfigurationAttribute a)
                ApplyBuilders(type, builder.RegisterConfigurationBinding(type, a.Path), attribute, builders);
        }

    }

}
