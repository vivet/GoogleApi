namespace GoogleApi.Entities.Interfaces
{
    /// <summary>
    /// Base interface for requests.
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Your application's API key (required). 
        /// This key identifies your application for purposes of quota management and so that Places added from your application are made immediately available to your app. 
        /// Visit the APIs Console to create an API Project and obtain your key.
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// The client ID provided to you by Google Enterprise Support, or null to disable URL signing. 
        /// All client IDs begin with a "gme-" prefix.
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// Determines if htttp or htttps is used when submitting the request.
        /// </summary>
        bool IsSsl { get; set; }

        /// <summary>
        /// Get the query string collection of aggregated from all parameters added to the request.
        /// </summary>
        QueryStringParameters QueryStringParameters { get; }
    }
}