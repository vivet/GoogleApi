using GoogleApi.Extensions;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Base abstract class for Maps requests.
    /// </summary>
    public abstract class BaseMapsChannelRequest : BaseMapsRequest
    {
        /// <summary>
        /// To track usage across different applications using the same client ID, you can use the channel parameter with your API requests. 
        /// By specifying different channel values for different aspects of your application, you can determine precisely how your application is used.
        /// For example, your external website might access an API using a channel set to customer, while your internal marketing department might 
        /// use a channel set to mkting.Your reports will break down usage of the API by those channel values.
        /// Make sure the channel value in your requests meets the following requirements:
        /// Must be an ASCII alphanumeric string.
        /// Can include a period(.), underscore(_) and hyphen(-) character.
        /// Is case-insensitive: Upper-case and mixed-case channel parameters are merged into their lower-case equivalent.For example, 
        /// usage on the CUSTOMER channel will be combined with the usage of the customer channel.
        /// Must be a static and assigned per application instance(it can't be generated dynamically). 
        /// For example, you can't use channel values to track individual users.
        /// </summary>
        public virtual string Channel { get; set; }

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        public override QueryStringParameters QueryStringParameters
        {
            get
            {
                var parameters = base.QueryStringParameters;

                if (!string.IsNullOrEmpty(this.Channel))
                    parameters.Add("channel", this.Channel);

                return parameters;
            }
        }
    }
}