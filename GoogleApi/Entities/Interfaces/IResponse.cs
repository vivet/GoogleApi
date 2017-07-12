namespace GoogleApi.Entities.Interfaces
{
    /// <summary>
    /// Base interface for responses.
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Raw json of the response.
        /// </summary>
        string RawJson { get; set; }

        /// <summary>
        /// Raw querystring of the request.
        /// </summary>
        string RawQueryString { get; set; }
    }
}