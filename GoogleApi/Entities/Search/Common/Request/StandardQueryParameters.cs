using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common.Request
{
    /// <summary>
    /// Define technical aspects of your request, like the API key or data format for the response (JSON or Atom).
    /// </summary>
    public class StandardQueryParameters
    {
        /// <summary>
        /// Alt - Data format for the response. (only json supported)
        /// Valid values: json, atom
        /// Default value: json
        /// </summary>
        public virtual AltType Alt { get; } = AltType.Json;

        /// <summary>
        /// fields - Selector specifying a subset of fields to include in the response.	
        /// For more information, see the partial response section in the Performance Tips document.
        /// Use for better performance. https://developers.google.com/custom-search/json-api/v1/performance#partial
        /// </summary>
        public virtual string Fields { get; set; }

        /// <summary>
        /// userIp IP address of the end user for whom the API call is being made.	
        /// Lets you enforce per-user quotas when calling the API from a server-side application.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public virtual string UserIp { get; set; }

        /// <summary>
        /// quotaUser Alternative to userIp.	
        /// Lets you enforce per-user quotas from a server-side application even in cases when the user's IP address is unknown. This can occur, for example, with applications that run cron jobs on App Engine on a user's behalf.
        /// You can choose any arbitrary string that uniquely identifies a user, but it is limited to 40 characters.
        /// Overrides userIp if both are provided.
        /// Learn more about Capping API usage. https://support.google.com/cloud/answer/7035610
        /// </summary>
        public virtual string QuotaUser { get; set; }

        /// <summary>
        /// PrettyPrint - Returns response with indentations and line breaks.
        /// Returns the response in a human-readable format if true.
        /// Default value: true.
        /// When this is false, it can reduce the response payload size, which might lead to better performance in some environments.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } = true;
    }
}