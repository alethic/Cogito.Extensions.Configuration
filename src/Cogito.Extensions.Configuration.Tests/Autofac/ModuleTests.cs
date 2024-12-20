using System.Collections.Generic;

using Autofac;

using Cogito.Autofac;
using Cogito.Extensions.Configuration.Autofac;

using FluentAssertions;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.Extensions.Configuration.Tests.Autofac
{

    [TestClass]
    public class ModuleTests
    {

        [TestMethod]
        public void Can_load_module()
        {
            var b = new ContainerBuilder();
            b.RegisterModule<Cogito.Extensions.Configuration.Tests.AssemblyModule>();
            var c = b.Build();
            var l = c.Resolve<IConfiguration>();
        }

        [TestMethod]
        public void Should_order_configuration_providers()
        {
            var b = new ContainerBuilder();
            b.RegisterModule<Cogito.Extensions.Configuration.Tests.AssemblyModule>();
            var c = b.Build();
            var l = c.Resolve<IConfiguration>();
            l.GetValue<string>("OrderedKey").Should().Be("ValueC");
        }

        [RegisterAs(typeof(IConfigurationBuilderConfiguration))]
        [RegisterOrder(5)]
        class ConfigurationBuilderC : IConfigurationBuilderConfiguration
        {

            public IConfigurationBuilder Apply(IConfigurationBuilder builder)
            {
                return builder.AddInMemoryCollection(new Dictionary<string, string>() { ["OrderedKey"] = "ValueC" });
            }

        }

        [RegisterAs(typeof(IConfigurationBuilderConfiguration))]
        [RegisterOrder(-5)]
        class ConfigurationBuilderA : IConfigurationBuilderConfiguration
        {

            public IConfigurationBuilder Apply(IConfigurationBuilder builder)
            {
                return builder.AddInMemoryCollection(new Dictionary<string, string>() { ["OrderedKey"] = "ValueA" });
            }

        }

        [RegisterAs(typeof(IConfigurationBuilderConfiguration))]
        [RegisterOrder(-4)]
        class ConfigurationBuilderB : IConfigurationBuilderConfiguration
        {

            public IConfigurationBuilder Apply(IConfigurationBuilder builder)
            {
                return builder.AddInMemoryCollection(new Dictionary<string, string>() { ["OrderedKey"] = "ValueB" });
            }

        }

    }

}
