[![](https://img.shields.io/nuget/v/soenneker.json.converters.abbreviatedsmartenum.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.converters.abbreviatedsmartenum/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.converters.abbreviatedsmartenum/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.json.converters.abbreviatedsmartenum/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.json.converters.abbreviatedsmartenum.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.json.converters.abbreviatedsmartenum/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.json.converters.abbreviatedsmartenum/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.json.converters.abbreviatedsmartenum/actions/workflows/codeql.yml)

# Soenneker.Json.Converters.AbbreviatedSmartEnum

A System.Text.Json AbbreviatedSmartEnum converter.

## Install

```bash
dotnet add package Soenneker.Json.Converters.AbbreviatedSmartEnum
```

## What you get

- `SmartEnumAbbreviationConverter<TEnum>` — A System.Text.Json AbbreviatedSmartEnum converter.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `SmartEnumAbbreviationConverter<TEnum>.Read(reader, typeToConvert, options)` | Executes the read operation. | The result of the operation. |
