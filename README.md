[![NuGet Package](https://github.com/lpreiner/IPAPI-Client/actions/workflows/publish.yml/badge.svg)](https://github.com/lpreiner/IPAPI-Client/actions/workflows/publish.yml)
[![NuGet](https://img.shields.io/nuget/v/IP-API.svg?style=flat&label=nuget&logo=nuget)](https://www.nuget.org/packages/IP-API/)

# IPAPI-Client
Simple client for ip-api.com with support for both free and pro endpoints

## Getting Started
```ps
Install-Package "IP-API"
```

## Usage

### Basic Query
```C#
var ipapiClient = new IPAPIClient();
var result = await ipapiClient.SearchAsync("1.1.1.1");
 ```

### Limit to Specific Field(s)
```C#
var result = await ipapiClient.SearchAsync("1.1.1.1", Field.CountryCode, Field.Organization);
 ```