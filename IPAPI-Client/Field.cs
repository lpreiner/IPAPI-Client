using System.Runtime.Serialization;

namespace IPAPIClient
{
	public enum Field
	{
		[EnumMember(Value = "status")]
		Status,

		[EnumMember(Value = "message")]
		Mesasge,

		[EnumMember(Value = "continent")]
		Continent,

		[EnumMember(Value = "continentCode")]
		ContinentCode,

		[EnumMember(Value = "country")]
		Country,

		[EnumMember(Value = "countryCode")]
		CountryCode,

		[EnumMember(Value = "region")]
		Region,

		[EnumMember(Value = "regionName")]
		RegionName,

		[EnumMember(Value = "city")]
		City,

		[EnumMember(Value = "district")]
		District,

		[EnumMember(Value = "zip")]
		Zip,

		[EnumMember(Value = "lat")]
		Latitude,

		[EnumMember(Value = "lon")]
		Longitude,

		[EnumMember(Value = "timezone")]
		TimeZone,

		[EnumMember(Value = "offset")]
		Offset,

		[EnumMember(Value = "currency")]
		Currency,

		[EnumMember(Value = "isp")]
		ISP,

		[EnumMember(Value = "org")]
		Organization,

		[EnumMember(Value = "as")]
		AutonomousSystemNumber,

		[EnumMember(Value = "asname")]
		AutonomousSystemName,

		[EnumMember(Value = "reverse")]
		Reverse,

		[EnumMember(Value = "mobile")]
		Mobile,

		[EnumMember(Value = "proxy")]
		Proxy,

		[EnumMember(Value = "hosting")]
		Hosting,

		[EnumMember(Value = "query")]
		Query,
	}
}
