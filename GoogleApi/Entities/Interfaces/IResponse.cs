using GoogleApi.Entities.Common.Enums;

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
        /// <summary>
        /// The status returned with the response.
        /// <see cref="GoogleApi.Entities.Common.Enums.Status.Ok"/> indicates success.
        /// </summary>
        Status? Status { get; set; }
    }
}