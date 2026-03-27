using AngleSharp.Html.Parser;
using System;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.AngleSharp.Parser.Enums;

namespace Soenneker.AngleSharp.Parser.Abstract;

/// <summary>
/// A thread-safe cache of AngleSharp HtmlParser instances keyed by context type.
/// </summary>
public interface IAngleSharpParser : IAsyncDisposable, IDisposable
{
    ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default);

    ValueTask<HtmlParser> Get(AngleSharpContextType contextType, CancellationToken cancellationToken = default);
}
