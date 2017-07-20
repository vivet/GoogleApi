## GoogleApi v3.0.0
Seamless Google Api integrations.
Supports Maps, Places, Roads, Search and Translate.  
Feel free to contribute, throw questions and report issues. I usually respond fast (24-48 hours).

##### Nuget: https://www.nuget.org/packages/GoogleApi (netstandard1.2, net4.5)

##### Highlights (v3.0):
* All Google endpoints updated (Maps, Places, Translate).
* Downgrade to netstandard1.2 (more portable platforms support, i think).
* Walk-through of all endpoints aligned with Google Api Documentation.
* Request validation improved for all endpoints (all cases covered).
* Error / Exception handling aligned for all Api's. New GoogleApiException, thrown when errors and http exception isn't thrown.
* Added missing endpoints. All Api's are now complete.
* Improvements to Language and Country Enums / Extensions (aligned with Google, isolated for all endpoints).
* Type and Namespace cleanup. Base / Common entities refactored.
* Test Suite expanded greatly. 90% or overall average coverage.

##### Known Issues (v3.0):
* Geolocation sometimes respond with 400 Bad Request.

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
    * Radar (*deprecated June 30th 2018*)
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
