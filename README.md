# Google Api
[![Build status](https://ci.appveyor.com/api/projects/status/ogah0hor3j6hmklv/branch/master?svg=true)](https://ci.appveyor.com/project/vivet/googleapi/branch/master)
[![NuGet](https://img.shields.io/nuget/dt/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi)
[![NuGet](https://img.shields.io/nuget/v/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi)

Seamless Google Api integrations.  
Google Maps, Places, Roads, Search and Translate.  

Feel free to contribute, throw questions and report issues. **I usually respond fast (24-48 hours).**  
Do you need support for an additional .Net framework?, let me know.  

### Using the Library
The library may be consumed, either by using the individual facede implementations or by depdendency injecting the individual api's.  
Each api implementation consists of a request and a response. The request has properties reflecting the parameters supported, and the response represents the object model for the returned json.  

A few other noteworthy members.

```csharp
var uri = request.GetUri(); // Gets the full request uri, including query parameters.
var params = request.GetQUeryStringParameters(); // Gets a list of all the added parameters.
```
```csharp
response.RawJson // The raw json returned by Google.
response.RawQueryString // The querystring sent to Google when invoking the request.
```

#### Facade
Each api has a generic facade operation to execute the request and return the response.  
The example below, simply populates a request, invokes the facade operation, and recieves the response in return.  
```csharp
TRequest request = new TRequest();
TResponse response = await {Api}.[{SubGroup}].{Action}.QueryAsync<TRequest, TResponse>(request);
```
See below for a full list of supported Api's and actions.  


#### Dependency Injection
If injecting the api's as dependencies is preffered register the services during startup, as shown below.  

```csharp
services
    .AddGoogleApis();
```
Then, inject the individual Api's in constructors as needed
```csharp
public class MyClass
{
    private {Api}.[{SubGroup}].{Action} api;
    
    public MyClass({Api}.[{SubGroup}].{Action} api)
    {
        this.api = api
    }
}
```
See below for a full list of supported Api's and actions.  

*** 

### Supported Api's
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
  * Video (*beta*)
    * Channels
	* Playlists
	* Vidoes

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

The test project stores settings related to your Google subscription (free or paid) in `application.default.json`.  
Most importantly, the ```ApiKey```, used to identify the Google subscription.  
```json
{ 
  "ApiKey": "",
  "SearchEngineId": "",
}
```
More information about generating a key can be found here: https://console.developers.google.com/  

*** 
