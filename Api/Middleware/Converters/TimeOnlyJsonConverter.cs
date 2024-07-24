using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.Middleware.Converters;

public sealed class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timeString = reader.GetString() + "";
        if (timeString.Length == 5) timeString += ":00";
        return TimeOnly.Parse(timeString, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("O");
        writer.WriteStringValue(isoDate);
    }
}