[![](https://img.shields.io/nuget/v/soenneker.json.converters.abbreviatedsmartenum.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.converters.abbreviatedsmartenum/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.converters.abbreviatedsmartenum/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.converters.abbreviatedsmartenum/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.converters.abbreviatedsmartenum/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.converters.abbreviatedsmartenum/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.json.converters.abbreviatedsmartenum.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.converters.abbreviatedsmartenum/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.converters.abbreviatedsmartenum/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.json.converters.abbreviatedsmartenum/actions/workflows/codeql.yml)

# Soenneker.Json.Converters.AbbreviatedSmartEnum

A `System.Text.Json` converter that writes an `AbbreviatedSmartEnum<T>` as its abbreviation and resolves that abbreviation when reading.

## Install

```bash
dotnet add package Soenneker.Json.Converters.AbbreviatedSmartEnum
```

## Define an abbreviated SmartEnum

```csharp
using Soenneker.SmartEnum.Abbreviated;

public sealed class OrderStatus : AbbreviatedSmartEnum<OrderStatus>
{
    public static readonly OrderStatus Pending = new("Pending", 1, "P");
    public static readonly OrderStatus Shipped = new("Shipped", 2, "S");

    private OrderStatus(string name, int value, string abbreviation)
        : base(name, value, abbreviation)
    {
    }
}
```

## Register and use the converter

```csharp
using System.Text.Json;
using Soenneker.Json.Converters.AbbreviatedSmartEnum;

var options = new JsonSerializerOptions();
options.Converters.Add(
    new SmartEnumAbbreviationConverter<OrderStatus>());

string json = JsonSerializer.Serialize(OrderStatus.Shipped, options);
// "S"

OrderStatus? status =
    JsonSerializer.Deserialize<OrderStatus>("\"P\"", options);
// OrderStatus.Pending
```

The JSON representation is the `Abbreviation` string, not the smart enum's name or numeric value. Reading a non-string token or an abbreviation that has no registered instance throws `JsonException`.

Abbreviation matching follows the `ignoreCase` behavior configured by the abbreviated SmartEnum type. Keep abbreviations unique under that comparison mode; duplicate definitions prevent the SmartEnum lookup from initializing.
