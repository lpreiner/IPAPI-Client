using System.Text.Json.Serialization;

namespace IPAPIClient
{
	public class ErrorResult
	{
		/// <summary>success or fail</summary>
		[JsonPropertyName("status")]
		public Status Status { get; set; }

		/// <summary>included only when status is fail.  Can be one of the following: private range, reserved range, invalid query</summary>
		[JsonPropertyName("message")]
		public string Message { get; set; }
	}
}
