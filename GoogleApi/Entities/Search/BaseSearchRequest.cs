using System;
using System.Collections.Generic;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Common.Extensions;

namespace GoogleApi.Entities.Search
{
    /// <summary>
    /// Base abstract class for Search requests.
    /// </summary>
    public abstract class BaseSearchRequest : BaseRequest, IRequestQueryString
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/";

        /// <summary>
        /// Alt - Data format for the response. (only json supported)
        /// Valid values: json, atom
        /// Default value: json
        /// </summary>
        public virtual AltType Alt => AltType.Json;

        /// <summary>
        /// Allowed values are web or image. If unspecified, results are limited to webpages.
        /// </summary>
        protected SearchType SearchType { get; set; } = SearchType.Web;

        /// <summary>
        /// Required. 
        /// Use the q query parameter to specify your search expression.
        /// </summary>
        public virtual string Query { get; set; }

        /// <summary>
        /// Callback function.
        /// Name of the JavaScript callback function that handles the response.
        /// Used in JavaScript JSON-P requests
        /// </summary>
        public virtual string Callback { get; set; }

        /// <summary>
        /// fields - Selector specifying a subset of fields to include in the response.	
        /// For more information, see the partial response section in the Performance Tips document.
        /// Use for better performance. https://developers.google.com/custom-search/json-api/v1/performance#partial
        /// </summary>
        public virtual string Fields { get; set; }

        /// <summary>
        /// PrettyPrint - Returns response with indentations and line breaks.
        /// Returns the response in a human-readable format if true.
        /// Default value: true.
        /// When this is false, it can reduce the response payload size, which might lead to better performance in some environments.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } = true;

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
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{KeyValuePair}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("Key is required");

            if (string.IsNullOrEmpty(this.Query))
                throw new ArgumentException("Query is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("q", this.Query);
            parameters.Add("alt", this.Alt.ToString().ToLower());

            if (this.Callback != null)
                parameters.Add("callback", this.Callback);

            if (this.Fields != null)
                parameters.Add("fields", this.Fields);

            parameters.Add("prettyPrint", this.PrettyPrint.ToString().ToLower());

            if (this.UserIp != null)
                parameters.Add("userIp", this.UserIp);

            if (this.QuotaUser != null)
                parameters.Add("quotaUser", this.QuotaUser);

            return parameters;
        }
    }
}