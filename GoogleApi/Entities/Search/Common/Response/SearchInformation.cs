using System.Runtime.Serialization;

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
        [DataMember(Name = "searchTime")]
        public virtual double SearchTime { get; set; }

        /// <summary>
        /// The time taken for the server to return search results, formatted according to locale style.
        /// </summary>
        [DataMember(Name = "formattedSearchTime")]
        public virtual string SearchTimeFormatted { get; set; }

        /// <summary>
        /// The total number of search results returned by the query.
        /// </summary>
        [DataMember(Name = "totalResults")]
        public virtual long TotalResults { get; set; }

        /// <summary>
        /// The total number of search results, formatted according to locale style.
        /// </summary>
        [DataMember(Name = "formattedTotalResults")]
        public virtual string TotalResultsFormatted { get; set; }
    }
}