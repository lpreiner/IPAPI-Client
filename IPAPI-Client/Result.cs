using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IPAPIClient
{
	public class Result
	{
		/// <summary>IP used for the query</summary>
		[JsonPropertyName("query")]
		public string Query { get; set; }

		/// <summary>success or fail</summary>
		[JsonPropertyName("status")]
		public Status Status { get; set; }

		/// <summary>Continent name</summary>
		[JsonPropertyName("continent")]
		public string Continent { get; set; }

		/// <summary>Two-letter continent code</summary>
		[JsonPropertyName("continentCode")]
		public string ContinentCode { get; set; }

		/// <summary>Country name</summary>
		[JsonPropertyName("country")]
		public string Country { get; set; }

		/// <summary>Two-letter country code <see href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO 3166-1 alpha-2</see></summary>
		[JsonPropertyName("countryCode")]
		public string CountryCode { get; set; }

		/// <summary>Region/state short code (FIPS or ISO)</summary>
		[JsonPropertyName("region")]
		public string Region { get; set; }

		/// <summary>Region/state</summary>
		[JsonPropertyName("regionName")]
		public string RegionName { get; set; }

		/// <summary>City</summary>
		[JsonPropertyName("city")]
		public string City { get; set; }

		/// <summary>District (subdivision of city)</summary>
		[JsonPropertyName("district")]
		public string District { get; set; }

		/// <summary>Zip code</summary>
		[JsonPropertyName("zip")]
		public string Zip { get; set; }

		/// <summary>Latitude</summary>
		[JsonPropertyName("lat")]
		public decimal? Latitude { get; set; }

		/// <summary>Longitude</summary>
		[JsonPropertyName("lon")]
		public decimal? Longitude { get; set; }

		/// <summary>Timezone (tz)</summary>
		[JsonPropertyName("timezone")]
		public string Timezone { get; set; }

		/// <summary>Timezone UTC DST offset in seconds</summary>
		[JsonPropertyName("offset")]
		public int? Offset { get; set; }

		/// <summary>National currency</summary>
		[JsonPropertyName("currency")]
		public string Currency { get; set; }

		/// <summary>ISP name</summary>
		[JsonPropertyName("isp")]
		public string ISP { get; set; }

		/// <summary>Organization name</summary>
		[JsonPropertyName("org")]
		public string Organization { get; set; }

		/// <summary>	AS number and organization, separated by space (RIR). Empty for IP blocks not being announced in BGP tables.</summary>
		[JsonPropertyName("as")]
		public string AutonomousSystemNumber { get; set; }

		/// <summary>AS name (RIR). Empty for IP blocks not being announced in BGP tables.</summary>
		[JsonPropertyName("asname")]
		public string AutonomousSystemName { get; set; }

		/// <summary>Reverse DNS of the IP (can delay response)</summary>
		[JsonPropertyName("reverse")]
		public string Reverse { get; set; }

		/// <summary>Mobile (cellular) connection</summary>
		[JsonPropertyName("mobile")]
		public bool? Mobile { get; set; }

		/// <summary>Proxy, VPN or Tor exit address</summary>
		[JsonPropertyName("proxy")]
		public bool? Proxy { get; set; }

		/// <summary>Hosting, colocated or data center</summary>
		[JsonPropertyName("hosting")]
		public bool? Hosting { get; set; }
	}

}
