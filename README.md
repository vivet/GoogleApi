# Google Api
[![NuGet](https://img.shields.io/nuget/dt/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi/)
[![NuGet](https://img.shields.io/nuget/v/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi/)

Seamless Google Api integrations.  
Google Maps, Places, Roads, Search and Translate.  

Feel free to contribute, throw questions and report issues. **I usually respond fast (24-48 hours).**  

### Api Operations
All operations, as well as request and response data points is supported and covered in the implementation. The library is very easy to consume, and using the service operations, is as seamless as shown below.
```csharp
TRequest request = new TRequest();
TResponse response = await GoogleMaps.Geocode.QueryAsync<TRequest, TResponse>(request);
```
The ```TRequest``` represents a request model, with an abitrary number of properties, defining the required and optional parameters supported by the Google api operation, corresponding to the request. The ```TResponse``` defines the response model returned by the Google api operation. Each operation has a request and response, mapped to a facade implementation.  

The following operations are supported.
##### Google Maps
  * Directions
  * Distance Matrix
  * Elevation
  * Geocode
  * Reverse Geocode
  * Geolocation
  * Roads
    * Nearest Roads
    * Snap To Roads
    * Speed Limits
  * Time Zone
  * Street View
  * Static Maps

##### Google Places
  * Place Search
    * Near By
    * Text
  * Place Details
  * Place Photos
  * Place Autocomplete
  * Query Autocomplete

##### Google Search
  * Web
  * Image

##### Google Translate
  * Detect
  * Languages
  * Translate

##### Google Functions
  * MergePolyLine
  * EncodePolyLine
  * DecodePolyLine

### Test Suite
Running the test suite is simple.  

The test project stores settings related to your Google subscription (free or paid) in `application.default.json`. Most importantly, the ```ApiKey```, used to identify the Google subscription.  
```json
{ 
  "ApiKey": "",
  "CryptoKey": "",
  "ClientId": "",
  "SearchEngineId": "",
}
```
More information about generating a key can be found here: https://console.developers.google.com/  
