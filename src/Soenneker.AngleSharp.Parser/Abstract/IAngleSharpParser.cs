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
    /// <summary>
    /// Returns the configured HTML Parser used by the anglesharp parser.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTML Parser.</returns>
    ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the configured HTML Parser used by the anglesharp parser.
    /// </summary>
    /// <param name="contextType">AngleSharp browsing context configuration to use.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTML Parser.</returns>
    ValueTask<HtmlParser> Get(AngleSharpContextType contextType, CancellationToken cancellationToken = default);
}
