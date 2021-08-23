using IPAPIClient.Serialization;
using System.Text.Json.Serialization;

namespace IPAPIClient
{
	[JsonConverter(typeof(JsonEnumStringConverter<Status>))]
	public enum Status
	{
		[JsonValue("success")]
		Success,

		[JsonValue("fail")]
		Fail
	}
}
