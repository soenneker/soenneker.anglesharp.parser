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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HtmlParser> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="contextType">The context type.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<HtmlParser> Get(AngleSharpContextType contextType, CancellationToken cancellationToken = default);
}
