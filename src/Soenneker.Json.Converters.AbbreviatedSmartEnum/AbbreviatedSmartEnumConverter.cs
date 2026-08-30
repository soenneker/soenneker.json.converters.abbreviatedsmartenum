using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.SmartEnum.Abbreviated;

namespace Soenneker.Json.Converters.AbbreviatedSmartEnum;

/// <summary>
/// Serializes an abbreviated smart enum as its abbreviation string.
/// </summary>
/// <typeparam name="TEnum">The abbreviated smart-enum type.</typeparam>
public sealed class SmartEnumAbbreviationConverter<TEnum> : JsonConverter<TEnum> where TEnum : AbbreviatedSmartEnum<TEnum>
{
    /// <summary>
    /// Reads an abbreviation string and resolves the corresponding smart-enum instance.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">The options.</param>
    /// <returns>The smart-enum instance matching the abbreviation.</returns>
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                return GetFromAbbreviation(reader.GetString()!);

            default:
                throw new JsonException($"Unexpected token {reader.TokenType} when parsing a smart enum.");
        }
    }

    /// <summary>
    /// Writes the smart enum's abbreviation as a JSON string.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="value">The value.</param>
    /// <param name="options">The options.</param>
    public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value.Abbreviation);
    }

    private static TEnum GetFromAbbreviation(string abbreviation)
    {
        try
        {
            return AbbreviatedSmartEnum<TEnum>.FromAbbreviation(abbreviation);
        }
        catch (Exception ex)
        {
            throw new JsonException($"Error converting value '{abbreviation}' to a smart enum.", ex);
        }
    }
}
