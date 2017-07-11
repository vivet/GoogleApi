## GoogleApi v3.0.0
Simple and easy Google Api integrations.  
Supports Maps, Places, Roads, Custom Search and Translate.  
https://www.nuget.org/packages/GoogleApi (net4.5, netstandard1.2)


NOTE: Feel free to report any issues, as well as create a PR for suggested changes / fixes.  

--------------------------------------------------------------------------------------------------------------------------------------------
TODO:
- LazyLoad Response.RawJson (if not already) so it doesn't waste ressources.
- Move QueryStringParameter to GoogleApi.Entities.Common
- Add solution folder for tests.
- ALl project 'warn as error' for docs doesn't seems to work.
- Figure out language handling with all google Api's
  - and PBMT and NMT for translate? how does it work?
- Refactor all 'QueryStringParameters' to 'Build'? or something
  - Create the new method and call that from the base 'QueryStringParameters' and mark it obsolete, for backward compatibility
  - Create Base Translate Request / (Response)
--------------------------------------------------------------------------------------------------------------------------------------------



### Google Api Integrations:
##### Google Maps
  * Directions
  * Distance Matrix
  * Elevation
  * Geocoding 
  * Reverse Geocoding
  * Geolocation
  * Roads 
    * Nearest Roads
    * Snap To Roads
    * Speed Limits
  * Time Zone

##### Google Places
  * Place Search
    * Near By
	* Text
	* Radar
  * Place Details
  * Place Add
  * Place Delete
  * Place Photos
  * Place Autocomplete
  * Query Autocomplete

##### Google Search (*Alpha*)
  * Web
  * Image
  * Enterprise (Paid)

##### Google Translate 
  * Detect
  * Languages
  * Translate

##### Google Functions 
  * MergePolyLine
  * EncodePolyLine
  * DecodePolyLine