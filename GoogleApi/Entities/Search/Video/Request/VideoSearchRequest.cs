using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search.Video.Request.Enums;

namespace GoogleApi.Entities.Search.Video.Request
{
    // TODO: https://developers.google.com/youtube/v3/getting-started


    /// <summary>
    /// Video Search Request.
    /// </summary>
    public class VideoSearchRequest : BaseRequest, IRequestQueryString
    {
        /// <summary>
        /// BaseUrl property overriden.
        /// </summary>
        protected internal override string BaseUrl => "www.googleapis.com/youtube/v3";

        /// <summary>
        /// A resource is an individual data entity with a unique identifier.
        /// </summary>
        public virtual ActionType Action { get; set; }

        /// <summary>
        /// A resource is an individual data entity with a unique identifier.
        /// </summary>
        public virtual OperationType Operation { get; set; }

        /// <summary>
        /// The part parameter identifies groups of properties that should be returned for a resource.
        /// </summary>
        public virtual string Part { get; set; }

        /// <summary>
        /// The fields parameter filters the API response to only return specific properties within the requested resource parts.
        /// </summary>
        public virtual string Fields { get; set; }
    }
}