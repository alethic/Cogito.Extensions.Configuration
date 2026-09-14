# Cogito.Extensions.Configuration

Configuration sources for code that still has to read `System.Configuration`, plus a `.json` provider
that walks up the directory tree.

## Why

Moving a .NET Framework application onto `IConfiguration` stalls on the parts that still call
`ConfigurationManager.AppSettings`. These providers expose the legacy `appSettings` and
`connectionStrings` sections as ordinary configuration, so both APIs see the same values and the
migration can happen a caller at a time rather than all at once.

## Install

```shell
dotnet add package Cogito.Extensions.Configuration
```

## Reading the legacy sections

```csharp
var configuration = new ConfigurationBuilder()
    .AddConfigurationManagerAppSetting()
    .AddConfigurationManagerConnectionString()
    .Build();
```

## Layered json files

```csharp
builder.AddParentJsonFiles("appsettings.json");
```

Loads that file from every directory from the application's own upwards, nearest last — so a solution
can keep shared settings at the root and let each application override them.

`Bind` binds a section onto an existing instance rather than constructing one.

## License

MIT.
