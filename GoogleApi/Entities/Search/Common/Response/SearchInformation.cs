using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Encapsulates all information about the search.
    /// </summary>
    [DataContract]
    public class SearchInformation
    {
        /// <summary>
        /// The time taken for the server to return search results.
        /// </summary>
        [JsonProperty("searchTime")]
        public virtual double SearchTime { get; set; }

        /// <summary>
        /// The time taken for the server to return search results, formatted according to locale style.
        /// </summary>
        [JsonProperty("formattedSearchTime")]
        public virtual string SearchTimeFormatted { get; set; }

        /// <summary>
        /// The total number of search results returned by the query.
        /// </summary>
        [JsonProperty("totalResults")]
        public virtual long TotalResults { get; set; }

        /// <summary>
        /// The total number of search results, formatted according to locale style.
        /// </summary>
        [JsonProperty("formattedTotalResults")]
        public virtual string TotalResultsFormatted { get; set; }
    }
}