# Cogito.Extensions.Configuration

[![Build](https://github.com/alethic/Cogito.Extensions.Configuration/actions/workflows/Cogito.Extensions.Configuration.yml/badge.svg)](https://github.com/alethic/Cogito.Extensions.Configuration/actions/workflows/Cogito.Extensions.Configuration.yml)

Configuration sources for code still reading System.Configuration, and configuration assembled from what the container contributes.

## Packages

**[Cogito.Extensions.Configuration](https://www.nuget.org/packages/Cogito.Extensions.Configuration)** — Configuration sources for code that still has to read `System.Configuration`, plus a `.json` provider that walks up the directory tree.

**[Cogito.Extensions.Configuration.Autofac](https://www.nuget.org/packages/Cogito.Extensions.Configuration.Autofac)** — Builds `IConfigurationRoot` inside the Autofac container, assembled from whatever the container's components contribute.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.Extensions.Configuration.slnx
dotnet msbuild -p:Configuration=Release Cogito.Extensions.Configuration.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
