using GoogleApi.Entities.Maps.Common;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Address Validation Response.
/// The response to an address validation request.
/// </summary>
public class AddressValidationResponse : BaseResponse
{
    /// <summary>
    /// Response Id.
    /// The UUID that identifies this response.
    /// If the address needs to be re-validated, this UUID must accompany the new request.
    /// </summary>
    public virtual string ResponseId { get; set; }

    /// <summary>
    /// Result.
    /// The result of the address validation.
    /// </summary>
    public virtual ValidationResult Result { get; set; }

    /// <summary>
    /// Error.
    /// </summary>
    public virtual Error Error { get; set; }

    /// <summary>
    /// Error Message.
    /// </summary>
    [JsonIgnore]
    public override string ErrorMessage => this.Error?.Message;

    /// <summary>
    /// Status.
    /// </summary>
    [JsonIgnore]
    public override Status Status => this.Error?.Status ?? base.Status;
}