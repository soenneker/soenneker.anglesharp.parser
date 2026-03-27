using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.AngleSharp.Parser.Abstract;

namespace Soenneker.AngleSharp.Parser.Registrars;

/// <summary>
/// A thread-safe singleton for the AngleSharp HtmlParser.
/// </summary>
public static class AngleSharpParserRegistrar
{
    /// <summary>
    /// Adds <see cref="IAngleSharpParser"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddAngleSharpParserAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IAngleSharpParser, AngleSharpParser>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAngleSharpParser"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddAngleSharpParserAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IAngleSharpParser, AngleSharpParser>();

        return services;
    }
}
