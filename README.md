[![](https://img.shields.io/nuget/v/soenneker.anglesharp.parser.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.anglesharp.parser/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.anglesharp.parser/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.anglesharp.parser/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.anglesharp.parser.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.anglesharp.parser/)

# Soenneker.AngleSharp.Parser

A DI-friendly cache of configured AngleSharp `HtmlParser` instances.

Instead of constructing parser configuration throughout an application, request one of three named parser contexts. The service creates each context on first use and returns the cached instance on later calls.

## Installation

```bash
dotnet add package Soenneker.AngleSharp.Parser
```

## Registration

Use singleton registration when the parser cache should be shared by the application:

```csharp
using Soenneker.AngleSharp.Parser.Registrars;

builder.Services.AddAngleSharpParserAsSingleton();
```

Scoped registration creates an independent cache for each dependency-injection scope:

```csharp
builder.Services.AddAngleSharpParserAsScoped();
```

Both registrars use `TryAdd`, so an existing `IAngleSharpParser` registration is not replaced.

## Parse HTML

Inject `IAngleSharpParser`, retrieve the appropriate configuration, and use the returned AngleSharp parser normally:

```csharp
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Soenneker.AngleSharp.Parser.Abstract;
using Soenneker.AngleSharp.Parser.Enums;

public sealed class PageTitleReader
{
    private readonly IAngleSharpParser _parsers;

    public PageTitleReader(IAngleSharpParser parsers)
    {
        _parsers = parsers;
    }

    public async ValueTask<string?> Read(
        string html,
        CancellationToken cancellationToken)
    {
        HtmlParser parser = await _parsers.Get(
            AngleSharpContextType.Fast,
            cancellationToken);

        using IDocument document = await parser.ParseDocumentAsync(
            html,
            cancellationToken);

        return document.QuerySelector("title")?.TextContent.Trim();
    }
}
```

`Get()` without a context argument is equivalent to `Get(AngleSharpContextType.Default)`.

## Parser contexts

| Context | Configuration | Use it for |
| --- | --- | --- |
| `Default` | AngleSharp's default `HtmlParser` configuration. | General HTML parsing when no specialized behavior is needed. |
| `Fast` | Scripting disabled and no resource loader added. | Parsing supplied HTML for scraping, normalization, or querying without external resource loading. |
| `WithLoader` | Scripting enabled and AngleSharp's default loader configured with resource loading enabled. | Workflows that need a loader-enabled browsing context. |

Choose the context deliberately. `WithLoader` permits resource loading through its browsing context, so do not use it with untrusted input in environments where outbound requests must be restricted.

## Cache and lifetime behavior

The cache is keyed by `AngleSharpContextType`. Within one `IAngleSharpParser` service instance:

- the first request for a context creates its `HtmlParser`;
- subsequent requests for that context return the same parser instance;
- requests for different contexts return independently configured instances;
- concurrent cache initialization is coordinated by the underlying singleton-key dictionary.

The thread-safety guarantee applies to creating and retrieving cached entries. Because callers receive the same mutable `HtmlParser` object for a context, avoid changing its configuration after retrieval and validate concurrent parsing behavior against the AngleSharp version used by your application.

The service implements both `IDisposable` and `IAsyncDisposable`. Let the dependency-injection container dispose registered instances. If you construct `AngleSharpParser` yourself, dispose that service when its cache is no longer needed.

## API

| Method | Purpose |
| --- | --- |
| `Get(CancellationToken)` | Returns the cached `Default` parser. |
| `Get(AngleSharpContextType, CancellationToken)` | Returns the cached parser for the selected context. |
| `AddAngleSharpParserAsSingleton()` | Registers one application-wide parser cache. |
| `AddAngleSharpParserAsScoped()` | Registers one parser cache per DI scope. |
