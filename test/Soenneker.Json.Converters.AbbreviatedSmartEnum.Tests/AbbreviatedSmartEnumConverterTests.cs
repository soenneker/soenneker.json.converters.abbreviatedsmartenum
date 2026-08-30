using System.Text.Json;
using System.Threading.Tasks;
using Soenneker.SmartEnum.Abbreviated;
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

    [Test]
    public async Task Serializes_and_resolves_abbreviation()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new SmartEnumAbbreviationConverter<Status>());

        string json = JsonSerializer.Serialize(Status.Active, options);
        Status? result = JsonSerializer.Deserialize<Status>(json, options);

        await Assert.That(json).IsEqualTo("\"A\"");
        await Assert.That(result).IsSameReferenceAs(Status.Active);
    }

    private sealed class Status : AbbreviatedSmartEnum<Status>
    {
        public static readonly Status Active = new("Active", 1, "A");
        public static readonly Status Disabled = new("Disabled", 2, "D");

        private Status(string name, int value, string abbreviation) : base(name, value, abbreviation)
        {
        }
    }
}
