namespace Soenneker.AngleSharp.Parser.Enums;

/// <summary>
/// Represents the angle sharp context type values.
/// </summary>
public enum AngleSharpContextType
{
    /// <summary>
    /// Represents the default value.
    /// </summary>
    Default,
    /// <summary>
    /// Represents the fast value.
    /// </summary>
    Fast, // no CSS / JS (crawler mode)
    /// <summary>
    /// Represents the with loader value.
    /// </summary>
    WithLoader // future: fetch external resources
}
