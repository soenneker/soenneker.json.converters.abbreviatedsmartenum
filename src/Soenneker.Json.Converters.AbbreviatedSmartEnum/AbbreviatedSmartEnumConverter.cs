using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.SmartEnum.Abbreviated;

namespace Soenneker.Json.Converters.AbbreviatedSmartEnum;

/// <summary>
/// A System.Text.Json AbbreviatedSmartEnum converter
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public sealed class SmartEnumAbbreviationConverter<TEnum> : JsonConverter<TEnum> where TEnum : AbbreviatedSmartEnum<TEnum>
{
    /// <summary>
    /// Executes the read operation.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <param name="typeToConvert">The type to convert.</param>
    /// <param name="options">The options.</param>
    /// <returns>The result of the operation.</returns>
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
    /// Executes the write operation.
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