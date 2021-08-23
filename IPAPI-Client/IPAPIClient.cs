using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace IPAPIClient
{
	public class IPAPIClient
	{
		const string CONTENT_TYPE_JSON = "application/json";
		const string DEFAULT_FIELD_QUERY = "66846719"; // all available fields

		static HttpClient _httpClient;
		static IPAPIClient()
		{
			_httpClient = new HttpClient();
		}

		readonly Endpoint _endpoint;
		readonly string _apiKey;

		public IPAPIClient()
			: this(null, Endpoint.Public)
		{ }

		public IPAPIClient(string apiKey, Endpoint endpoint = null)
		{
			_apiKey = apiKey;
			_endpoint = endpoint ?? Endpoint.Pro;
		}

		public async Task<Result> SearchAsync(string ipAddress, params Field[] fields)
		{
			var url = $"/json/{HttpUtility.UrlEncode(ipAddress)}";
			var fieldQuery = GetFieldQuery(fields);
			if (fieldQuery != null)
				url += $"?fields={fieldQuery}";

			var result = await ExecuteJsonRequestAsync<Result>(HttpMethod.Get, url, null);

			return result.Data;
		}

		#region Helpers

		string GetFieldQuery(IEnumerable<Field> fields)
		{
			if (fields is null || !fields.Any())
				return DEFAULT_FIELD_QUERY;

			return string.Join(",", fields.Select(f => f.Map()));
		}

		async Task<Response<T>> ExecuteJsonRequestAsync<T>(HttpMethod method, string uri, object body = null)
		{
			using (var response = await ExecuteRequestAsync(method, uri, body))
			{
				if (!response.IsSuccessStatusCode)
				{
					switch (response.StatusCode)
					{
						case HttpStatusCode.Unauthorized:
						case HttpStatusCode.Forbidden:
							throw new Exception(response.ReasonPhrase);
						default:
							var content = await response.Content?.ReadAsStringAsync();
							//throw new Exception((int)response.StatusCode, content ?? response.ReasonPhrase);
							throw new Exception(content ?? response.ReasonPhrase);
					}
				}

				var contentType = response.Content?.Headers?.ContentType?.MediaType;
				if (response.StatusCode == HttpStatusCode.OK && contentType != CONTENT_TYPE_JSON)
					throw new Exception($"Unexpected content type: '{contentType}'.  Expected '{CONTENT_TYPE_JSON}'");

				return new Response<T>
				{
					StatusCode = response.StatusCode,
					Headers = response.Headers,
					Data = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync()),
				};
			}
		}

		async Task<HttpResponseMessage> ExecuteRequestAsync(HttpMethod method, string uri, object body = null)
		{
			var reqUri = new Uri(_endpoint.BaseUrl, uri);
			if (!string.IsNullOrEmpty(_apiKey))
				reqUri = reqUri.AddQueryParam("key", _apiKey);

			using (var request = new HttpRequestMessage(method, reqUri))
			{
				if (body != null)
					request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, CONTENT_TYPE_JSON);

				return await _httpClient.SendAsync(request);
			}
		}

        class Response<T>
		{
			public HttpStatusCode StatusCode { get; set; }
			public HttpHeaders Headers { get; set; }
			public T Data { get; set; }
		}
		#endregion
	}
}
