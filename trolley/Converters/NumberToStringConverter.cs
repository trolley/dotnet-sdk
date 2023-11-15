using System;
using Newtonsoft.Json;

namespace Trolley.Converters
{
    internal sealed class NumberToStringConverter : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;
        public override bool CanConvert(Type type) => type == typeof(double) || type == typeof(int);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            double number = (double)value;
            writer.WriteValue(String.Format("{0:0.00}", number));
        }

        public override object ReadJson(
            JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
