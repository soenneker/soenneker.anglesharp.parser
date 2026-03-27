namespace Soenneker.AngleSharp.Parser.Enums;

public enum AngleSharpContextType
{
    Default,
    Fast, // no CSS / JS (crawler mode)
    WithLoader // future: fetch external resources
}
