[![](https://img.shields.io/nuget/v/soenneker.anglesharp.parser.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.anglesharp.parser/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.anglesharp.parser/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.anglesharp.parser/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.anglesharp.parser.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.anglesharp.parser/)

# Soenneker.AngleSharp.Parser

A thread-safe cache of AngleSharp HtmlParser instances keyed by context type.

## Install

```bash
dotnet add package Soenneker.AngleSharp.Parser
```

## Quick start

```csharp
using Soenneker.AngleSharp.Parser.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddAngleSharpParserAsSingleton();
```

Adds `IAngleSharpParser` as a singleton service.

## What you get

- `IAngleSharpParser` — A thread-safe cache of AngleSharp HtmlParser instances keyed by context type.
- `AngleSharpParserRegistrar` — Registers the thread-safe AngleSharp parser cache service.
- `AngleSharpContextType` — Represents the angle sharp context type values.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AngleSharpParserRegistrar.AddAngleSharpParserAsSingleton(services)` | Adds `IAngleSharpParser` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `AngleSharpParserRegistrar.AddAngleSharpParserAsScoped(services)` | Adds `IAngleSharpParser` as a scoped service. | The same service collection, so additional registrations can be chained. |
| `AngleSharpContextType.Default` | Represents the default value. | Represents the default value. |
| `AngleSharpContextType.Fast` | Represents the fast value. | Represents the fast value. |
| `AngleSharpContextType.WithLoader` | Represents the with loader value. | Represents the with loader value. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
