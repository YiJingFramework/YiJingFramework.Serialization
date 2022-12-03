using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YiJingFramework.Serialization
{
    public sealed class JsonConverterOfStringConvertibleForJson<T> : JsonConverter<T>
        where T : IStringConvertibleForJson<T>
    {
        public override bool HandleNull => false;
        
        public override T Read(
            ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();

            var s = reader.GetString();
            Debug.Assert(s is not null);
            if (!T.FromStringForJson(s, out var result))
                throw new JsonException();
            return result;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToStringForJson());
        }
    }
}
