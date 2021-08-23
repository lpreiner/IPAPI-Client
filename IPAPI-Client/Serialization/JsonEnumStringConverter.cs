using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IPAPIClient.Serialization
{
	class JsonEnumStringConverter<T> : MappedEnumStringConverter<T> where T : Enum
	{
		public JsonEnumStringConverter()
			: base(GetMappedValues())
		{ }

		static IEnumerable<KeyValuePair<string, T>> GetMappedValues()
		{
			var values = new Dictionary<string, T>();

			var enumType = typeof(T);
			foreach (T value in enumType.GetEnumValues())
			{
				var memberInfo = enumType.GetMember(value.ToString()).First();
				var attributes = memberInfo.GetCustomAttributes(typeof(JsonValueAttribute), true)
					.OfType<JsonValueAttribute>();

				foreach (var attribute in attributes)
				{
					yield return new KeyValuePair<string, T>(attribute.Value, value);
				}
			}
		}
	}
}
