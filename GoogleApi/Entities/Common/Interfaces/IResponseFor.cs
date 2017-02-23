namespace GoogleApi.Entities.Common.Interfaces
{
    /// <summary>
    /// Interface used by http engine responses.
    /// </summary>
    public interface IResponseFor
    {
        /// <summary>
        /// The raw json of the response.
        /// </summary>
        string RawJson { get; set; }

        /// <summary>
        /// The raw querystring of the request.
        /// </summary>
        string RawQueryString { get; set; }
    }
}