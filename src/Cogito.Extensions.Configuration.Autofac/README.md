# Cogito.Extensions.Configuration.Autofac

Builds `IConfigurationRoot` inside the Autofac container, assembled from whatever the container's
components contribute.

## Why

Configuration is normally composed once at startup, before the container exists. That leaves no way
for an assembly to add a source of its own without editing startup — the opposite of how the rest of
a Cogito application is composed.

## Install

```shell
dotnet add package Cogito.Extensions.Configuration.Autofac
```

## Contributing a source

Register an `IConfigurationBuilderConfiguration` and it is applied when the root is built:

```csharp
[RegisterAs(typeof(IConfigurationBuilderConfiguration))]
public class MyConfiguration : IConfigurationBuilderConfiguration
{
    public void Add(IConfigurationBuilder builder) =>
        builder.AddJsonFile("my.json", optional: true);
}
```

Resolving `IConfiguration` or `IConfigurationRoot` then gives you everything every contributor added.
Any `IConfiguration` already registered in the container is chained in as well, so this composes with
configuration built the ordinary way.

## Binding a section to a type

```csharp
builder.RegisterConfigurationBinding<MySettings>("My:Section");
```

or declaratively, with `[RegisterConfiguration]` on the settings type.

`IConfigurationRootBuilder` is the seam if you need control over how the root is assembled.

## License

MIT.
