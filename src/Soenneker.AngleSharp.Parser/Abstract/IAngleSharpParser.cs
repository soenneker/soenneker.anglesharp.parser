using AngleSharp.Html.Parser;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.AngleSharp.Parser.Abstract;

/// <summary>
/// A thread-safe singleton for the AngleSharp HtmlParser.
/// </summary>
public interface IAngleSharpParser : IAsyncDisposable, IDisposable
{
    ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default);
}
