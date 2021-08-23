using System;
using System.Collections.Generic;
using System.Text;

namespace IPAPIClient
{
	public class Endpoint
	{
		const string BASE_URL_PUBLIC = "http://ip-api.com";
		const string BASE_URL_PRO = "https://pro.ip-api.com";

		public Uri BaseUrl { get; set; }

		public static Endpoint Public => new Endpoint(BASE_URL_PUBLIC);
		public static Endpoint Pro => new Endpoint(BASE_URL_PRO);

		public Endpoint(string baseUrl)
			: this(new Uri(baseUrl))
		{ }

		public Endpoint(Uri baseUrl)
			=> BaseUrl = baseUrl;
	}
}
