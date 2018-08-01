# Google Api
[![NuGet](https://img.shields.io/nuget/dt/GoogleApi.png?longCache=true)](https://www.nuget.org/packages/GoogleApi/)
[![NuGet](https://img.shields.io/nuget/v/GoogleApi.png?longCache=true)](https://www.nuget.org/packages/GoogleApi/)

Seamless Google Api integrations.  
Google Maps, Places, Roads, Search and Translate.  

Feel free to contribute, throw questions and report issues. **I usually respond fast (24-48 hours).**  

*** 

### Getting started...
The library is extremely seamless to consume and use.  
Each api implementation consists of a request and a response, as well as a generic facade operation to execute the request and return the response. The request has properties reflecting the parameters supported, and the response represents the object model for the returned json.  

The example below, simply populates a request, invokes the facade operation, and recieves the response in return.  
```csharp
TRequest request = new TRequest();
TResponse response = await {Api}.{Action}.QueryAsync<TRequest, TResponse>(request);
```

A few other noteworthy members.
##### Request
```csharp
var uri = request.GetUri(); // Gets the full request uri, including query parameters.
var params = request.GetQUeryStringParameters(); // Gets a list of all the added parameters.
```
##### Response
```csharp
response.RawJson // The raw json returned by Google.
response.RawQueryString // The querystring sent to Google when invoking the request.
```

*** 

### Supported Operations
The following operations are supported.

##### Google Maps
  * Directions
  * Distance Matrix
  * Elevation
  * Geocode
    * Place
    * Address
    * Location (reverse)
    * Plus Code
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
    * Find
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

*** 

### Running Test Suite
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

*** 
