using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Io;
using Soenneker.AngleSharp.Parser.Abstract;
using Soenneker.Dictionaries.SingletonKeys;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.AngleSharp.Parser.Enums;

namespace Soenneker.AngleSharp.Parser;

///<inheritdoc cref="IAngleSharpParser"/>
public sealed class AngleSharpParser : IAngleSharpParser
{
    private readonly SingletonKeyDictionary<AngleSharpContextType, HtmlParser> _instances;

    public AngleSharpParser()
    {
        _instances = new SingletonKeyDictionary<AngleSharpContextType, HtmlParser>(static contextType => CreateParser(contextType));
    }

    private static HtmlParser CreateParser(AngleSharpContextType contextType)
    {
        return contextType switch
        {
            AngleSharpContextType.Default => new HtmlParser(),
            AngleSharpContextType.Fast => new HtmlParser(new HtmlParserOptions
            {
                IsScripting = false
            }, BrowsingContext.New(Configuration.Default)),
            AngleSharpContextType.WithLoader => new HtmlParser(new HtmlParserOptions
            {
                IsScripting = true
            }, BrowsingContext.New(Configuration.Default.WithDefaultLoader(new LoaderOptions
            {
                IsResourceLoadingEnabled = true
            }))),
            _ => throw new ArgumentOutOfRangeException(nameof(contextType), contextType, null)
        };
    }

    public ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default)
    {
        return Get(AngleSharpContextType.Default, cancellationToken);
    }

    public ValueTask<HtmlParser> Get(AngleSharpContextType contextType, CancellationToken cancellationToken = default)
    {
        return _instances.Get(contextType, cancellationToken);
    }

    public void Dispose()
    {
        _instances.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _instances.DisposeAsync();
    }
}