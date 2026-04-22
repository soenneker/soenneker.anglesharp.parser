using Soenneker.AngleSharp.Parser.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.AngleSharp.Parser.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AngleSharpParserTests : HostedUnitTest
{
    private readonly IAngleSharpParser _util;

    public AngleSharpParserTests(Host host) : base(host)
    {
        _util = Resolve<IAngleSharpParser>(true);
    }

    [Test]
    public void Default()
    {

    }
}
