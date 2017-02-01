using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Places.Common
{
    /// <summary>
    /// Base abstract class for Places responses.
    /// </summary>
    [DataContract]
    public abstract class BasePlacesResponse : BaseResponse
    {
    }
}