# Google Api
[![Build status](https://ci.appveyor.com/api/projects/status/ogah0hor3j6hmklv/branch/master?svg=true)](https://ci.appveyor.com/project/vivet/googleapi/branch/master)
[![NuGet](https://img.shields.io/nuget/dt/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi)
[![NuGet](https://img.shields.io/nuget/v/GoogleApi.svg)](https://www.nuget.org/packages/GoogleApi)

Seamless Google Api integrations.  
Google Maps, Places, Roads, Search and Translate.  

Feel free to contribute, throw questions and report issues. **I usually respond fast (24-48 hours).**  
Do you need support for an additional .Net framework?, let me know.  

**New: Version 5.0.0 with Routes Api (directions and matrix), Ariel View Api and Address Validation Api.**  

***

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
The example below, simply populates a request, invokes the facade operation, and receives the response in return.  
```csharp
TRequest request = new TRequest();
TResponse response = await {Api}.[{SubGroup}].{Action}.QueryAsync<TRequest, TResponse>(request);
```
See below for a full list of supported Api's and actions.  


#### Dependency Injection
If injecting the api's as dependencies is preffered register the services during startup, as shown below.  

```csharp
services
    .AddGoogleApiClients();
```
Then, inject the individual Api's in constructors as needed
```csharp
public class MyClass
{
    private Api api;
    
    public MyClass(Api api)
    {
        this.api = api
    }
}
```
See below for a full list of supported Api's and actions.  

#### Proxy
If a ```WebProxy``` is required set the static property ```HttpClientFactory.Proxy``` before registrering the GoogleApi dependencies or using the Facade.  

*** 

### Supported Api's
The following api's are supported.

##### Google Maps
  * Directions (```GoogleMaps.Directions```)
  * Distance Matrix (```GoogleMaps.DistanceMatrix```)
  * Elevation (```GoogleMaps.Elevation```)
  * Geocode
    * Place (```GoogleMaps.Geocode.PlaceGeocode```)
    * Address (```GoogleMaps.Geocode.AddressGeocode```)
    * Location (reverse) (```GoogleMaps.Geocode.LocationGeocode```)
    * Plus Code (```GoogleMaps.Geocode.PlusCodeGeocode```)
  * Geolocation (```GoogleMaps.Geolocation```)
  * Roads
    * Nearest Roads (```GoogleMaps.Roads.NearestRoads```)
    * Snap To Roads (```GoogleMaps.Roads.SnapToRoad```)
    * Speed Limits (```GoogleMaps.Roads.SpeedLimits```)
  * Time Zone
  * Street View
  * Static Maps
  * Routes
    * RouteDirections (```GoogleMaps.Routes.Directions```)
    * RouteMatrix (```GoogleMaps.Routes.Matrix```)
  * Address Validation (```GoogleMaps.AddressValidation```)
  * Aerial View (*beta*)
    * Get Video (```GoogleMaps.AerialView.GetVideo```)
    * Render Video (```GoogleMaps.AerialView.RenderVideo```)

##### Google Places
  * Place Search
    * Find (```GooglePlaces.Search.FindSearch```)
    * Near By (```GooglePlaces.Search.NearBySearch```)
    * Text (```GooglePlaces.Search.TextSearch```)
  * Place Details (```GooglePlaces.Details```)
  * Place Photos (```GooglePlaces.Photos```)
  * Place Autocomplete (```GooglePlaces.AutoComplete```)
  * Query Autocomplete (```GooglePlaces.QueryAutoComplete```)

##### Google Search
  * Web (```GoogleSearch.WebSearch```)
  * Image (```GoogleSearch.ImageSearch```)
  * Video
    * Channels (```GoogleSearch.VideoSearch.Channels```)
    * Playlists (```GoogleSearch.VideoSearch.Playlists```)
    * Vidoes (```GoogleSearch.VideoSearch.Vidoes```)

##### Google Translate
  * Detect (```GoogleTranslate.Detect```)
  * Languages (```GoogleTranslate.Languages```)
  * Translate (```GoogleTranslate.Translate```)

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
