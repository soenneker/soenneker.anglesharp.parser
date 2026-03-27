using Soenneker.AngleSharp.Parser.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.AngleSharp.Parser.Tests;

[Collection("Collection")]
public sealed class AngleSharpParserTests : FixturedUnitTest
{
    private readonly IAngleSharpParser _util;

    public AngleSharpParserTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IAngleSharpParser>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
