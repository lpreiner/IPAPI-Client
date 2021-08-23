using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPAPIClient
{
	static class UriExtensions
	{
		public static Uri AddQueryParam(this Uri uri, string key, string value)
		{
			return AddQueryParam(new UriBuilder(uri), key, value).Uri;
		}

		public static UriBuilder AddQueryParam(this UriBuilder uri, string key, string value)
		{
			return AddQueryParams(uri, new KeyValuePair<string, IConvertible>(key, value));
		}

		public static UriBuilder AddQueryParams(this UriBuilder uri, params KeyValuePair<string, IConvertible>[] queryParams)
		{
			return AddQueryParams(uri, queryParams.AsEnumerable());
		}

		public static UriBuilder AddQueryParams(this UriBuilder uri, IEnumerable<KeyValuePair<string, IConvertible>> queryParams)
		{
			char getParamDelimterChar(string queryString)
			{
				switch (queryString?.FirstOrDefault())
				{
					case '?': return '&';
					default: return '?';
				}
			}

			foreach (var p in queryParams)
				uri.Query += $"{getParamDelimterChar(uri.Query)}{HttpUtility.UrlEncode(p.Key)}={HttpUtility.UrlEncode(p.Value?.ToString())}";

			return uri;
		}
	}
}
