using System;
using System.Collections.Generic;
using System.Text;

namespace IPAPIClient.Serialization
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	class JsonValueAttribute : Attribute
	{
		public string Value { get; }
		public JsonValueAttribute(string value) => Value = value;
	}
}
