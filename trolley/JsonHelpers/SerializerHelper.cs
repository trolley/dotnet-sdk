using System;
using Newtonsoft.Json;
using Trolley.Converters;

namespace Trolley.JsonHelpers
{
	public class SerializerHelper
	{
		public SerializerHelper()
		{
		}

        public static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                Converters = { new NumberToStringConverter() }                
            };
        }
    }
}

