using System.Net;

namespace GoogleApi.Engine
{
    /// <summary>
    /// Base class for generic engine.
    /// </summary>
    public abstract class GenericEngine
    {
        /// <summary>
        /// HttpServicePoint
        /// </summary>
        public static ServicePoint HttpServicePoint { get; protected set; }
        
        /// <summary>
        /// HttpsServicePoint
        /// </summary>
        public static ServicePoint HttpsServicePoint { get; protected set; }
    }
}