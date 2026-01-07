using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace adotePet.Utils

{
    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _format = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (DateTime.TryParseExact(dateString, _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }
            throw new JsonException($"Invalid date format. Expected format is {_format}.");
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
