using System.Collections.Generic;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Routes.Common;

/// <summary>
/// Status.
/// The Status type defines a logical error model that is suitable for different programming environments, including REST APIs and RPC APIs. It is used by gRPC.
/// Each Status message contains three pieces of data: error code, error message, and error details.
/// </summary>
public class GeocoderStatus
{
    /// <summary>
    /// Code.
    /// The status code, which should be an enum value of google.rpc.Code.
    /// </summary>
    public virtual int Code { get; set; }

    /// <summary>
    /// Message.
    /// A developer-facing error message, which should be in English.
    /// Any user-facing error message should be localized and sent in the google.rpc.Status.details field, or localized by the client.
    /// </summary>
    public virtual string Message { get; set; }

    /// <summary>
    /// Details.
    /// A list of messages that carry the error details.
    /// There is a common set of message types for APIs to use.
    /// An object containing fields of an arbitrary type. An additional field "@type" contains a URI identifying the type.
    /// Example: { "id": 1234, "@type": "types.example.com/standard/id" }.
    /// </summary>
    public virtual IEnumerable<ErrorDetail> Details { get; set; }
}