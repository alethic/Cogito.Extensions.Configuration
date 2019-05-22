using System;

using Cogito.Autofac;

namespace Cogito.Extensions.Configuration.Autofac
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterConfigurationAttribute :
        Attribute,
        IRegistrationRootAttribute
    {

        readonly string path;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        public RegisterConfigurationAttribute(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        /// <summary>
        /// Path of the configuration to be registered.
        /// </summary>
        public string Path => path;

        Type IRegistrationRootAttribute.HandlerType => typeof(RegisterConfigurationHandler);

    }

}
