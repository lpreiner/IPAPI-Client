using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IPAPIClient.Serialization
{
	class MappedEnumStringConverter<T> : JsonConverter<T> where T : Enum
	{
		readonly IDictionary<string, T> _mapping;
		readonly StringComparison _comparison;

		public MappedEnumStringConverter(IDictionary<string, T> mapping, StringComparison comparison = StringComparison.Ordinal)
		{
			_mapping = mapping;
			_comparison = comparison;
		}

		public MappedEnumStringConverter(IEnumerable<KeyValuePair<string, T>> mapping, StringComparison comparison = StringComparison.Ordinal)
			: this(mapping.ToDictionary(x => x.Key, x => x.Value), comparison)
		{ }

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(T);
		}

		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return Map(reader.GetString().ToString());
		}

		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(Map((T)value));
		}

		protected T Map(string value)
		{
			var key = _mapping.Keys.FirstOrDefault(k => k.Equals(value, _comparison));
			if (key is null)
				throw new InvalidOperationException($"Enum '{typeof(T).Name}' has no matching value for '{value}'");

			return _mapping[key];
		}

		protected string Map(T value)
		{
			var hasValue = _mapping.Any(m => m.Value.Equals(value));
			if (hasValue)
				return _mapping.First(m => m.Value.Equals(value)).Key;

			throw new InvalidOperationException($"Enum '{typeof(T).Name}' has no value mapping defined for '{value}'");
		}
	}
}
