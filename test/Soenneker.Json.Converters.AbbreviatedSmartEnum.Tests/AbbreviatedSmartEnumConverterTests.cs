using Soenneker.Tests.HostedUnit;

namespace Soenneker.Json.Converters.AbbreviatedSmartEnum.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class AbbreviatedSmartEnumConverterTests : HostedUnitTest
{
    public AbbreviatedSmartEnumConverterTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
