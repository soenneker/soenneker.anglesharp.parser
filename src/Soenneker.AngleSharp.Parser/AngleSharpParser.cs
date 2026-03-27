using AngleSharp.Html.Parser;
using Soenneker.AngleSharp.Parser.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.AngleSharp.Parser;

///<inheritdoc cref="IAngleSharpParser"/>
public sealed class AngleSharpParser : IAngleSharpParser
{
    private readonly AsyncSingleton<HtmlParser> _instance;

    public AngleSharpParser()
    {
        _instance = new AsyncSingleton<HtmlParser>(() => new HtmlParser());
    }

    public ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default)
    {
        return _instance.Get(cancellationToken: cancellationToken);
    }

    public void Dispose()
    {
        _instance.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _instance.DisposeAsync();
    }
}