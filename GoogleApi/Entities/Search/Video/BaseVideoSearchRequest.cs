using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Video.Common.Enums;
using GoogleApi.Entities.Search.Video.Common.Enums.Extensions;

namespace GoogleApi.Entities.Search.Video
{
    /// <summary>
    /// Base Video Search Request (abstract).
    /// </summary>
    public abstract class BaseVideoSearchRequest : BaseSearchRequest
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/youtube/v3/search";

        /// <summary>
        /// The part parameter specifies a comma-separated list of one or more search resource properties that the API response will include.
        /// Cannot be set. Currently, the implementation only support response part 'snippet'.
        /// </summary>
        public virtual PartType Part { get; } = PartType.Snippet;

        /// <summary>
        /// The location parameter, in conjunction with the locationRadius parameter, defines a circular geographic area and also restricts a search to videos that specify,
        /// in their metadata, a geographic location that falls within that area.
        /// The parameter value is a string that specifies latitude/longitude coordinates e.g. (37.42307,-122.08427).
        /// The location parameter value identifies the point at the center of the area.
        /// The locationRadius parameter specifies the maximum distance that the location associated with a video can be from that point for
        /// the video to still be included in the search results.  The API returns an error if your request specifies a value for the location parameter but does not
        /// also specify a value for the locationRadius parameter.
        /// </summary>
        public virtual Location Location { get; set; }

        /// <summary>
        /// The locationRadius parameter, in conjunction with the location parameter, defines a circular geographic area.
        /// The parameter value must be a floating point number followed by a measurement unit.Valid measurement units are m, km, ft, and mi. For example,
        /// valid parameter values include 1500m, 5km, 10000ft, and 0.75mi.
        /// The API does not support locationRadius parameter values larger than 1000 kilometers.
        /// Note: See the definition of the location parameter for more information.
        /// </summary>
        public virtual int? LocationRadiusInMeters { get; set; }

        /// <summary>
        /// The maxResults parameter specifies the maximum number of items that should be returned in the result set.
        /// Acceptable values are 0 to 50, inclusive.
        /// The default value is 5.
        /// </summary>
        public virtual int MaxResults { get; set; } = 5;

        /// <summary>
        /// The order parameter specifies the method that will be used to order resources in the API response.
        /// The default value is relevance.
        /// </summary>
        public virtual Order Order { get; set; } = Order.Relevance;
        
        /// <summary>
        /// The pageToken parameter identifies a specific page in the result set that should be returned.
        /// In an API response, the nextPageToken and prevPageToken properties identify other pages that could be retrieved.
        /// </summary>
        public virtual string PageToken { get; set; }

        /// <summary>
        /// The publishedAfter parameter indicates that the API response should only contain resources created at or after the specified time.
        /// The value is an RFC 3339 formatted date-time value(1970-01-01T00:00:00Z).
        /// </summary>
        public virtual DateTime? PublishedAfter { get; set; }

        /// <summary>
        /// The publishedBefore parameter indicates that the API response should only contain resources created before or at the specified time.
        /// The value is an RFC 3339 formatted date-time value(1970-01-01T00:00:00Z).
        /// </summary>
        public virtual DateTime? PublishedBefore { get; set; }

        /// <summary>
        /// The regionCode parameter instructs the API to return search results for videos that can be viewed in the specified country.
        /// The parameter value is an ISO 3166-1 alpha-2 country code.
        /// </summary>
        public virtual Country? Region { get; set; }

        /// <summary>
        /// The relevanceLanguage parameter instructs the API to return search results that are most relevant to the specified language.
        /// The parameter value is typically an ISO 639-1 two-letter language code.
        /// However, you should use the values zh-Hans for simplified Chinese and zh-Hant for traditional
        /// </summary>
        public virtual Language? RelevanceLanguage { get; set; }

        /// <summary>
        /// The safeSearch parameter indicates whether the search results should include restricted content
        /// as well as standard content.
        /// </summary>
        public virtual SafeSearch SafeSearch { get; set; } = SafeSearch.None;

        /// <summary>
        /// The topicId parameter indicates that the API response should only
        /// contain resources associated with the specified topic.
        /// </summary>
        public virtual string TopicId { get; set; }
        
        /// <summary>
        /// See <see cref="BaseRequest.GetQueryStringParameters()"/>.
        /// </summary>
        /// <returns>The <see cref="IList{T}"/> collection.</returns>
        public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();

            if (this.MaxResults <= 0 || this.MaxResults > 50)
                throw new ArgumentOutOfRangeException(nameof(this.MaxResults));

            parameters.Add("type", this.SearchType.ToString().ToLower());

            var parts = Enum.GetValues(typeof(PartType))
                .Cast<PartType>()
                .Where(x => this.Part.HasFlag(x))
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

            parameters.Add("part", parts.EndsWith(",") ? parts.Substring(0, parts.Length - 1) : parts);

            if (this.Location != null)
            {
                parameters.Add("location", this.Location.ToString());

                if (this.LocationRadiusInMeters.HasValue)
                    parameters.Add("locationRadius", $"{this.LocationRadiusInMeters}m");
            }

            parameters.Add("maxResults", this.MaxResults.ToString());

            parameters.Add("order", this.Order.ToString().ToLower());

            if (this.PageToken != null)
                parameters.Add("nextPageToken", this.PageToken);

            if (this.PublishedAfter.HasValue)
                parameters.Add("publishedAfter", this.PublishedAfter.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            if (this.PublishedBefore.HasValue)
                parameters.Add("publishedBefore", this.PublishedBefore.Value.DateTimeToUnixTimestamp().ToString(CultureInfo.InvariantCulture));

            if (this.Region.HasValue)
                parameters.Add("regionCode", this.Region.Value.ToCode());

            if (this.RelevanceLanguage.HasValue)
                parameters.Add("relevanceLanguage", this.RelevanceLanguage.Value.ToCode());

            parameters.Add("safeSearch", this.SafeSearch.ToString().ToLower());

            if (this.TopicId != null)
                parameters.Add("topicId", this.TopicId);

            return parameters;
        }
    }
}