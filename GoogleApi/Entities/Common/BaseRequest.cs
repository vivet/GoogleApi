using System;
using System.Collections.Generic;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Base abstract class for requests.
    /// </summary>
    public abstract class BaseRequest
    {
        /// <summary>
        /// Base Url for the request.
        /// </summary>
        protected internal abstract string BaseUrl { get; }

        /// <summary>
        /// Your application's API key (required). 
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app. 
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// True to indicate that request comes from a device with a location sensor, otherwise false. 
        /// This information is required by Google and does not affect the results.
        /// </summary>
        /// <remarks>
        /// It is unclear if Google refers to the device performing the request or the source of the location data.
        /// In the geocoding API reference at https://developers.google.com/maps/documentation/geocoding/ the definition is:
        /// 
        ///     sensor (required) — Indicates whether or not the geocoding request comes from a device with a location sensor.
        /// 
        /// This implies that only mobile devices that are equipped with a location sensor (such as GPS) should set the Sensor value 
        /// to True. So if a location is sent to a web server which then calls the Google API, it apparently should set the Sensor
        /// value to false, since the web server isn't a location sensor equipped device.
        /// 
        /// In another page of their documentation, https://developers.google.com/maps/documentation/javascript/tutorial they say:
        /// 
        ///     The sensor parameter of the URL must be included, and indicates whether this application uses a sensor (such as a GPS 
        ///     locator) to determine the user's location.
        /// 
        /// This implies something completely different, that the Sensor value must be set to true if the source of the location
        /// information is a sensor or not, regardless if the request is being performed by a location sensor equipped device or not.
        /// </remarks>
        public virtual bool Sensor { get; set; }

        /// <summary>
        /// True to use use the https protocol; false to use http. 
        /// The default is false.
        /// </summary>
        public virtual bool IsSsl { get; set; }

        public virtual IDictionary<string, string> QueryStringParameters
        {
            get
            {
                var parameters = new Dictionary<string, string>();

                if (this.ClientId == null)
                {
                    if (!string.IsNullOrWhiteSpace(this.Key))
                        parameters.Add("key", this.Key);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(this.Key))
                        throw new ArgumentException("Key is required.");

                    if (!this.ClientId.StartsWith("gme-"))
                        throw new ArgumentException("ClientId must begin with 'gme-'.");
                }

                parameters.Add("sensor", Sensor.ToString().ToLower());

                return parameters;
            }
        }
    }
}