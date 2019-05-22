using System;

using Autofac;
using Autofac.Builder;

using Microsoft.Extensions.Configuration;

namespace Cogito.Extensions.Configuration.Autofac
{

    public static class ContainerBuilderExtensions
    {

        /// <summary>
        /// Registers a type provided by the <see cref="IConfigurationRoot"/> at the given path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterConfigurationBinding<T>(this ContainerBuilder builder, string path)
            where T : class, new()
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return builder.Register(ctx => ctx.Resolve<IConfigurationRoot>().Bind<T>(path));
        }

        /// <summary>
        /// Registers a type provided by the <see cref="IConfigurationRoot"/> at the given path.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IRegistrationBuilder<object, SimpleActivatorData, SingleRegistrationStyle> RegisterConfigurationBinding(this ContainerBuilder builder, Type type, string path)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return builder.Register(ctx => ctx.Resolve<IConfigurationRoot>().Bind(type, path)).As(type);
        }

    }

}
